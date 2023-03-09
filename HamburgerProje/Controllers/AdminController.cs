using HamburgerProje.Data;
using HamburgerProje.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

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

        public IActionResult MenuOlustur(Menu gelenMenu)
        {

            if (gelenMenu.Id == 0)
            {
                var menuVm = new MenuViewModel();
                var menu = new Menu();
                _db.Menuler.Add(menu);
                _db.SaveChanges();

                menuVm.Id = menu.Id;
                return View(menuVm);
            }

            var menuVm2 = new MenuViewModel();
            var menu2 = _db.Menuler
                .Include(x => x.Hamburgerler)
                .Include(x => x.Ekstralar)
                .Include(x => x.Soslar)
                .Include(x => x.Icecekler).ToList()
                .FirstOrDefault(x => x.Id == gelenMenu.Id);



            menu2.Hamburgerler.AddRange(_db.Hamburgerler.Where(x => x.Id ==menu2.Id).ToList());
            _db.SaveChanges();

            ViewBag.Menu = _db.Menuler.FirstOrDefault(x => x.Id == gelenMenu.Id);

            menuVm2.Id = menu2.Id;
            menuVm2.Hamburgerler = menu2.Hamburgerler;
            menuVm2.Ekstralar = menu2.Ekstralar;
            menuVm2.Soslar = menu2.Soslar;
            menuVm2.Icecekler = menu2.Icecekler;

            return View(menuVm2);
        }

        [HttpPost]
        public IActionResult MenuOlustur(MenuViewModel vm)
        {
            if (ModelState.IsValid)
            {
                string dosyaAd = "";
                if (vm.Resim !=null)
                {
                    dosyaAd = vm.Resim.FileName;
                    string kayitYolu = Path.Combine(_env.WebRootPath, "img", dosyaAd); //  wwwroot / img // asset 16.jpg
                    using (var stream = new FileStream(kayitYolu, FileMode.OpenOrCreate))
                    {
                        vm.Resim.CopyTo(stream);
                    }

                }
                var menu = _db.Menuler.Find(vm.Id);


                menu.Ad = vm.Ad;
                menu.Fiyat = vm.Fiyat;
                menu.Resim = dosyaAd;


                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(vm);
        }


        [HttpPost]
        public IActionResult MenuEkle(DbViewModel vm, int id)
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

        [HttpPost]
        public IActionResult SosEkle(DbViewModel vm)
        {
            if (ModelState.IsValid)
            {
                string dosyaAd = vm.SosViewModel!.Resim.FileName;
                string kayitYolu = Path.Combine(_env.WebRootPath, "img", dosyaAd); //  wwwroot / img // asset 16.jpg
                using (var stream = new FileStream(kayitYolu, FileMode.OpenOrCreate))
                {
                    vm.SosViewModel.Resim.CopyTo(stream);
                }

                _db.Soslar.Add(new Sos()
                {
                    Ad = vm.SosViewModel.Ad,
                    Fiyat = vm.SosViewModel.Fiyat,
                    Resim = dosyaAd
                });

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(vm);
        }

        [HttpPost]
        public IActionResult EkstraEkle(DbViewModel vm)
        {
            if (ModelState.IsValid)
            {
                string dosyaAd = vm.EkstraViewModel!.Resim.FileName;
                string kayitYolu = Path.Combine(_env.WebRootPath, "img", dosyaAd); //  wwwroot / img // asset 16.jpg
                using (var stream = new FileStream(kayitYolu, FileMode.OpenOrCreate))
                {
                    vm.EkstraViewModel.Resim.CopyTo(stream);
                }

                _db.Ekstralar.Add(new Ekstra()
                {
                    Ad = vm.EkstraViewModel.Ad,
                    Fiyat = vm.EkstraViewModel.Fiyat,
                    Resim = dosyaAd
                });

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(vm);
        }

        [HttpPost]
        public IActionResult IcecekEkle(DbViewModel vm)
        {
            if (ModelState.IsValid)
            {
                string dosyaAd = vm.IcecekViewModel!.Resim.FileName;
                string kayitYolu = Path.Combine(_env.WebRootPath, "img", dosyaAd); //  wwwroot / img // asset 16.jpg
                using (var stream = new FileStream(kayitYolu, FileMode.OpenOrCreate))
                {
                    vm.IcecekViewModel.Resim.CopyTo(stream);
                }

                _db.Icecekler.Add(new Icecek()
                {
                    Ad = vm.IcecekViewModel.Ad,
                    Fiyat = vm.IcecekViewModel.Fiyat,
                    Resim = dosyaAd
                });

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(vm);
        }

        public IActionResult MenuyeHamburgerEkle(int id, int menuId)
        {
            var hamburger = _db.Hamburgerler.Find(id);

            var menu = _db.Menuler.Find(menuId);

            _db.Entry(menu).Collection(x => x.Hamburgerler).Load();
            menu.Hamburgerler.Add(hamburger);

            _db.SaveChanges();


            return RedirectToAction("MenuOlustur", menu);
        }

        public IActionResult MenuyeSosEkle(int id, int menuId)
        {
            var sos = _db.Soslar.Find(id);

            var menu = _db.Menuler.Find(menuId);
            menu.Soslar.Add(sos);
            _db.SaveChanges();


            return RedirectToAction("MenuOlustur", menu);
        }

        public IActionResult MenuyeIcecekEkle(int id, int menuId)
        {
            var icecek = _db.Icecekler.Find(id);

            var menu = _db.Menuler.Find(menuId);
            menu.Icecekler.Add(icecek);
            _db.SaveChanges();


            return RedirectToAction("MenuOlustur", menu);
        }

        public IActionResult MenuyeEkstraEkle(int id, int menuId)
        {
            var ekstra = _db.Ekstralar.Find(id);

            var menu = _db.Menuler.Find(menuId);
            menu.Ekstralar.Add(ekstra);
            _db.SaveChanges();


            return RedirectToAction("MenuOlustur", menu);
        }


        // action'a ek olarak menü id istiyecez. eğer menü id varsa o menüyü bulup içine ekle. menü id yoksa yeni menü oluştur
    }
}
