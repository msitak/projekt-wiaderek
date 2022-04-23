namespace Magazyn.Models
{
    public class Kategoria
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Produkt>? Produkty { get; set; }
    }
}