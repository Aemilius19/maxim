using Maxim.DAL;
using Maxim.Models;
using Microsoft.AspNetCore.Mvc;

namespace Maxim.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ServiceController : Controller
	{
		AppDbContext _context;
		private readonly IWebHostEnvironment _environment;

		public ServiceController(AppDbContext context,IWebHostEnvironment environment)
		{
			_context = context;
			_environment = environment;
		}

		public IActionResult Index()
		{
			var services= _context.Services.ToList();
			return View(services);
		}
		public IActionResult Create() 
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Services services)
		{
			if (!ModelState.IsValid) { return View(); }
			string path = _environment.WebRootPath + @"\admin\upload\service\";
			string filename = services.ImgFile.FileName;
			using(FileStream stream=new FileStream(path+filename, FileMode.Create)) 
			{
				services.ImgFile.CopyTo(stream);
				services.ImgUrl = filename;
			}
			_context.Services.Add(services);
			_context.SaveChanges();
			return RedirectToAction("Index");

		}

		public IActionResult Delete(int id)
		{
			var service = _context.Services.FirstOrDefault(s => s.Id == id);
			_context.Services.Remove(service);
			_context.SaveChanges();
            string path = _environment.WebRootPath + @"\admin\upload\service\";
            FileInfo file = new FileInfo(path+service.ImgUrl);
			if (file.Exists)
			{
				file.Delete();
			}
			return RedirectToAction("Index");
		}
		public IActionResult Update(int id)
		{
			var services = _context.Services.FirstOrDefault(x=>x.Id == id);
			return View(services);
		}
		[HttpPost]
		public IActionResult Update(Services service)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
            var services = _context.Services.FirstOrDefault(x => x.Id == service.Id);
            string path = _environment.WebRootPath + @"\admin\upload\service\";
            string filename = service.ImgFile.FileName;
            FileInfo file = new FileInfo(path + services.ImgUrl);
            if (file.Exists)
            {
                file.Delete();
            }
            using (FileStream stream = new FileStream(path + filename, FileMode.Create))
            {
                service.ImgFile.CopyTo(stream);
                services.ImgUrl = filename;
            }
			services.Title = service.Title;
			services.Description = service.Description;
			_context.SaveChanges();

            return RedirectToAction("Index");

        }

	}
}
