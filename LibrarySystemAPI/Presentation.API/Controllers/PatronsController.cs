using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controllers
{
    
    public class PatronsController : BasAPIController
    {
        private readonly IPatronService _patronService;
        private readonly IMapper _mapper;

        public PatronsController(IPatronService patronService, IMapper mapper)
        {
            _patronService = patronService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatronDto>>> GetAll()
        {
            var patrons = await _patronService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<PatronDto>>(patrons));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatronDto>> GetById(int id)
        {
            var patron = await _patronService.GetByIdAsync(id);
            if (patron == null)
                return NotFound();

            return Ok(_mapper.Map<PatronDto>(patron));
        }

        [HttpPost]
        public async Task<ActionResult> Add(PatronDto patronDto)
        {
            var patron = _mapper.Map<Patron>(patronDto);
            await _patronService.AddAsync(patron);
            return CreatedAtAction(nameof(GetById), new { id = patron.Id }, patronDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PatronDto patronDto)
        {
            var patron = _mapper.Map<Patron>(patronDto);
            patron.Id = id;
            await _patronService.UpdateAsync(patron);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _patronService.DeleteAsync(id);
            return NoContent();
        }
    }
}
