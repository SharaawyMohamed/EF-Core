using Core.Services;
using Core.Services;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.DTOs;
using Core.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace OrderSystem.Settings.Controllers
{

    public class UserController : ApiBaseController
    {
        private readonly ITokenService _jwtService;
        private readonly IEmailService _emailService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInmanager;
        public UserController(UserManager<AppUser> usermanager, SignInManager<AppUser> signInmanager, ITokenService jwtService,IEmailService emailService)
        {
            _jwtService = jwtService;
            _emailService = emailService;
            _userManager = usermanager;
            _signInmanager = signInmanager;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] UserDto model)
        {
            var user = new AppUser()
            {
                UserName = model.Email.Split('@')[0],
                Email = model.Email,
            };
            var isfound =await _userManager.FindByEmailAsync(model.Email);
            if(isfound != null) {
                return BadRequest("User Already Registere");
            }
            var state = await _userManager.CreateAsync(user, model.Password);
            if (!state.Succeeded)
            {
                return BadRequest("Registration Failed");
            }
            await _userManager.AddToRoleAsync(user, "Customer");// Default Role For Users
            var email = new Email()
            {
                To=model.Email,
                Subject="Welcome Dear In Our Website",
            };
            await _emailService.SendEmailAsync(email);
            return Ok(new UserDtoResponse()
            {
                Username = user.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Token = await _jwtService.GenerateToken(user, _userManager)
            }); ;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDtoResponse>> Login([FromBody] UserDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null)
            {
                return Unauthorized(401);
            }

            var state = await _signInmanager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!state.Succeeded) return Unauthorized(401);
            return Ok(new UserDtoResponse()
            {
                Username = user.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Token = await _jwtService.GenerateToken(user, _userManager)
            });
        }
    }
}

