using GroceriesTool.DAL.Models;
using GroceriesTool.DAL.Repositories;
using GroceriesTool.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GroceriesTool.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public Repository<Groceries> GroceriesRepository { get; }
        public Repository<Stores> StoresRepository { get; }

        public HomeController(Repository<Groceries> groceriesRepository, Repository<Stores> storesRepository)
        {
            GroceriesRepository = GroceriesRepository;
            StoresRepository = storesRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        public async Task<IActionResult> Groceries()
        {
            var viewModel = (await GroceriesRepository.GetAll()).Select(x => new GrocerieViewModel
            {
                Id = x.Id,
                StoreName = x.StoreName,
                BuyLocation = x.BuyLocation,
                Code = x.Code,
                Price = x.Price,
                Product = x.Product,
                Stock = x.Stock
            });
            ViewData["Message"] = "All the storage is on this page (well it needs to be).";
            return View(viewModel);
        }

        public async Task<IActionResult> Stores()
        {
            var viewModel = (await StoresRepository.GetAll()).Select(x => new StoreViewModel
            {
                Id = x.Id,
                Closinghours = x.Closinghours,
                Openinghours = x.Openinghours,
                StoreLocation = x.StoreLocation,
                StoreName = x.StoreName
            });
            ViewData["Message"] = "Place all the stores in this tabel";
            return View(viewModel);
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
