using HamburgerProje.Data;
using HamburgerProje.Models;
using Microsoft.AspNetCore.Mvc;

namespace HamburgerProje.Controllers
{
    public class AdminController : Controller
    {
        private readonly UygulamaDbContext _db;
        private readonly IWebHostEnvironment _env;

        public AdminController(UygulamaDbContext db, IWebHostEnvironment env)
        {
            _db=db;
            _env=env;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MenuEkle(MenuViewModel vm)
        {
            if (ModelState.IsValid)
            {
                string dosyaAd = vm.Resim.FileName;
                string kayitYolu = Path.Combine(_env.WebRootPath, "img", dosyaAd);
                using (var stream = new FileStream(kayitYolu, FileMode.OpenOrCreate))
                {
                    vm.Resim.CopyTo(stream);
                }

                _db.Menuler.Add(new Menu()
                {
                    Ad = vm.Ad,
                    Fiyat = vm.Fiyat,
                    Resim = dosyaAd
                });
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);
        }
    }
}
