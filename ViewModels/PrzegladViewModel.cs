using Magazyn.Models;

namespace Magazyn.ViewModels
{
    public class PrzegladViewModel
    {
        public string Filtr { get; set; }
        public IList<Produkt>? Produkty { get; set; }
    }
}
