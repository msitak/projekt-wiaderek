using Magazyn.Data;
using Magazyn.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Magazyn.Controllers
{
    public class PrzegladController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrzegladController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new PrzegladViewModel();
            viewModel.Produkty = await _context.Produkt.Include(x => x.Kategoria).ToListAsync();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Filtruj([Bind("Filtr,Produkty")] PrzegladViewModel viewModel)
        {
            if (String.IsNullOrEmpty(viewModel.Filtr))
            {
                viewModel.Produkty = await _context.Produkt.Include(x => x.Kategoria).OrderBy(x => x.Kategoria).ToListAsync();
            }
            else
            {
                viewModel.Produkty = await _context.Produkt.Include(x => x.Kategoria).Where(z => z.Kategoria.Name.Contains(viewModel.Filtr)).OrderBy(x => x.Kategoria).ToListAsync();
            }
            return View("Index", viewModel);
        }
    }
}
