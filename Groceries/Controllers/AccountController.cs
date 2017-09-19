using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GroceriesTool.Models;

namespace GroceriesTool.Controllers
{
    [Authorize]
    public class GroceriesToolController : Controller
    {
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

            var viewModel = new List<DAL.Models.Groceries>();

            using (var dbContext = new DAL.Context.DatabaseContext())
            {
                var GroceriesRepository = new DAL.repository.GroceriesRepository(dbContext);

                viewModel = (await GroceriesRepository.GetAll()).ToList();
                ViewData["Message"] = "All the storage is on this page (well it needs to be).";
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Stores()
        {
            var viewModel = new List<DAL.Models.Stores>();

            using (var dbContext = new DAL.Context.DatabaseContext())
            {
                var storeRepository = new DAL.repository.StoresRepository(dbContext);

                viewModel = (await storeRepository.GetAll()).ToList();
                ViewData["Message"] = "Place all the stores in this tabel";
            }
            return View(viewModel);
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
