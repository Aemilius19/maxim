
using Maxim.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Maxim.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _context;

		public HomeController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
        {
            var services=_context.Services.ToList();
            return View(services);
        }
    }
}
