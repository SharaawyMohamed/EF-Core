using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestMe.Models;

namespace TestMe.Controllers
{
	public class HomeController : Controller
	{
		
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

	}
}
