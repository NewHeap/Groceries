using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GroceriesTool.Models;
using GroceriesTool.DAL.Models;
using GroceriesTool.DAL.Repositories;

namespace GroceriesTool.Controllers
{
    [Authorize]
    public class GroceriesController : Controller
    {
        private IRepository<Groceries> GroceriesRepository { get; set; }

        public GroceriesController(IRepository<Groceries> groceriesRepository)
        {
            GroceriesRepository = groceriesRepository;
        }

        // GET: Groceries
        public async Task<IActionResult> Index()
        {
            var viewModel = (await GroceriesRepository.GetAllAsync()).Select(item => new GrocerieViewModel
            {
                Id = item.Id,
                Product = item.Product,
                Stock = item.Stock,
                Price = item.Price,
                Code = item.Code,
                BuyLocation = item.BuyLocation,
                StoreName = item.StoreName
            }).ToList();
            return View(viewModel);
        }

        // GET: Groceries/Details/5
        public async Task<IActionResult> Details(int id)
        {
                var Grocerie = await GroceriesRepository.FindAsync(id);
                if (Grocerie == null) return RedirectToAction(nameof(Index));
                return View(new GrocerieViewModel
                {
                    Id = Grocerie.Id,
                    Product = Grocerie.Product,
                    Stock = Grocerie.Stock,
                    Price = Grocerie.Price,
                    Code = Grocerie.Code,
                    BuyLocation = Grocerie.BuyLocation,
                    StoreName = Grocerie.StoreName
                });
        }

        // GET: Groceries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Groceries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GrocerieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var Grocerie = new Groceries
                {
                    Id = model.Id,
                    Product = model.Product,
                    Stock = model.Stock,
                    Price = model.Price,
                    Code = model.Code,
                    BuyLocation = model.BuyLocation,
                    StoreName = model.StoreName
                };
                GroceriesRepository.Add(Grocerie);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Groceries/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
                var Grocerie = await GroceriesRepository.FindAsync(id);
                if (Grocerie == null) return RedirectToAction(nameof(Index));
                return View(new GrocerieViewModel
                { 
                    Id = Grocerie.Id,
                    Product = Grocerie.Product,
                    Stock = Grocerie.Stock,
                    Price = Grocerie.Price,
                    Code = Grocerie.Code,
                    BuyLocation = Grocerie.BuyLocation,
                    StoreName = Grocerie.StoreName
                });
        }


        // POST: Groceries/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(GrocerieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                    var Grocerie = await GroceriesRepository.FindAsync(model.Id);
                    Grocerie.Id = model.Id;
                    Grocerie.Product = model.Product;
                    Grocerie.Stock = model.Stock;
                    Grocerie.Price = model.Price; 
                    Grocerie.Code = model.Code;
                    Grocerie.BuyLocation = model.BuyLocation;
                    Grocerie.StoreName = model.StoreName;
                    await GroceriesRepository.UpdateAsync(Grocerie);
                    return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Groceries/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
                var Grocerie = await GroceriesRepository.FindAsync(id);
                if (Grocerie == null) return RedirectToAction(nameof(Index));
                return View(new GrocerieViewModel
                {
                    Id = Grocerie.Id,
                    Product = Grocerie.Product,
                    Stock = Grocerie.Stock,
                    Price = Grocerie.Price,
                    Code = Grocerie.Code,
                    BuyLocation = Grocerie.BuyLocation,
                    StoreName = Grocerie.StoreName

                });
        }

        // POST: Groceries/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(GrocerieViewModel model)
        {
            try
            {
                    ///var i = await GroceriesRepository.FindAsync(model.Id);
                    GroceriesRepository.Remove(model.Id);
                    await GroceriesRepository.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Groceries/Stock
        [HttpGet]
        public async Task<IActionResult> Stock(int id)
        {
            //var viewModel = new List<Groceries>();

            var viewModel = (await GroceriesRepository.GetAllAsync()).Select(x => new GrocerieViewModel
            {
                Id = x.Id,
                Product = x.Product,
                Stock = x.Stock,
            }).ToList();
            return View(viewModel);
        }


        // POST: Groceries/Stock
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Stock(GrocerieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please check fields for errer");
                return View(model);
            }
            try
            {
                await GroceriesRepository.SaveChangesAsync();
                return Ok();
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditStock(int id, int stock)
        {
            try
            {
                var grocerie = await GroceriesRepository.FindAsync(id);
                if (grocerie == null) return RedirectToAction(nameof(Index));
                grocerie.Stock = stock.ToString();
                await GroceriesRepository.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}