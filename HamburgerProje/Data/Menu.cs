using System.ComponentModel.DataAnnotations.Schema;

namespace HamburgerProje.Data
{
    public class Menu
    {
        public int Id { get; set; }
        public string? Ad { get; set; } = null!;
        public double Fiyat { get; set; }
        public int Adet { get; set; }
        public List<Hamburger> Hamburgerler { get; set; } = new();
        public List<Icecek> Icecekler { get; set; } = new();
        public List<Sos> Soslar { get; set; } = new();
        public List<Ekstra> Ekstralar { get; set; } = new();
        public List<Siparis> Siparisler { get; set; } = new();
        public string? Resim { get; set; } = null!;

    }
}
