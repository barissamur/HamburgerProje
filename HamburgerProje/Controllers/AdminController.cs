using HamburgerProje.Data;
using HamburgerProje.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;

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
        public IActionResult MenuEkle(DbViewModel vm)
        {
            if (ModelState.IsValid)
            {
                string dosyaAd = vm.MenuViewModel.Resim.FileName;
                string kayitYolu = Path.Combine(_env.WebRootPath, "img", dosyaAd); //  wwwroot / img // asset 16.jpg
                using (var stream = new FileStream(kayitYolu, FileMode.OpenOrCreate))
                {
                    vm.MenuViewModel.Resim.CopyTo(stream);
                }

                _db.Menuler.Add(new Menu()
                {
                    Ad = vm.MenuViewModel.Ad,
                    Fiyat = vm.MenuViewModel.Fiyat,
                    Resim = dosyaAd
                });

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(vm);
        }

        [HttpPost]
        public IActionResult HamburgerEkle(DbViewModel vm)
        {
            if (ModelState.IsValid)
            {
                string dosyaAd = vm.HamburgerViewModel!.Resim.FileName;
                string kayitYolu = Path.Combine(_env.WebRootPath, "img", dosyaAd); //  wwwroot / img // asset 16.jpg
                using (var stream = new FileStream(kayitYolu, FileMode.OpenOrCreate))
                {
                    vm.HamburgerViewModel.Resim.CopyTo(stream);
                }

                _db.Hamburgerler.Add(new Hamburger()
                {
                    Ad = vm.HamburgerViewModel.Ad,
                    Fiyat = vm.HamburgerViewModel.Fiyat,
                    Resim = dosyaAd
                });

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(vm);
        }

        public IActionResult MenuyeHamburgerEkle(int id)
        {
            if (id != null)
            {
                var hamburger = _db.Hamburgerler.Find(id);
                var yeniMenuVm = new MenuViewModel();
                yeniMenuVm.Hamburgerler.Add(hamburger);

                var yeniMenu = new Menu();
        

                if (yeniMenu != null && hamburger != null)
                {
                    yeniMenu.Hamburgerler.Add(hamburger);

                    _db.Menuler.Add(yeniMenu);
                    _db.SaveChanges();
                }
            }

            return Json(_db.Hamburgerler);
        }
    }
}
