namespace Magazyn.Models
{
    public class Produkt
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public int KategoriaId { get; set; }
        public Kategoria? Kategoria { get; set; }
    }
}
