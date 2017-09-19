﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GroceriesTool.Models;
using GroceriesTool.DAL.Models;

namespace GroceriesTool.Controllers
{
    [Authorize]
    public class GroceriesController : Controller
    {
        // GET: Groceries
        public async Task<IActionResult> Index()
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

        // GET: Groceries/Details/5
        public async Task<IActionResult> Details(int id)
        {
            using (var dbContext = new DAL.Context.DatabaseContext())
            {
                var GroceriesRepository = new DAL.repository.GroceriesRepository(dbContext);
                var Grocerie = await GroceriesRepository.Find(id);
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
                ModelState.AddModelError("", "Please check fields for errer");
                return View(model);
            }
            try
            {
                using (var dbContext = new DAL.Context.DatabaseContext())
                {
                    var GroceriesRepository = new DAL.repository.GroceriesRepository(dbContext);
                    var Grocerie = new Groceries();
                    GroceriesRepository.Add(Grocerie);
                    return RedirectToAction(nameof(Index));
                }
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
            using (var dbContext = new DAL.Context.DatabaseContext())
            {
                var GroceriesRepository = new DAL.repository.GroceriesRepository(dbContext);
                var Grocerie = await GroceriesRepository.Find(id);
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
                throw new Exception();
            }
        }


        // POST: Groceries/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(GrocerieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please check fields for errer");
                return View(model);
            }
            try
            {
                using (var dbContext = new DAL.Context.DatabaseContext())
                {
                    var GroceriesRepository = new DAL.repository.GroceriesRepository(dbContext);
                    var Grocerie = await GroceriesRepository.Find(model.Id);
                    Grocerie.Id = model.Id;
                    Grocerie.Product = model.Product;
                    Grocerie.Stock = model.Stock;
                    Grocerie.Price = model.Price; 
                    Grocerie.Code = model.Code;
                    Grocerie.BuyLocation = model.BuyLocation;
                    Grocerie.StoreName = model.StoreName;
                    await dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
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
            using (var dbContext = new DAL.Context.DatabaseContext())
            {
                var GroceriesRepository = new DAL.repository.GroceriesRepository(dbContext);
                var Grocerie = await GroceriesRepository.Find(id);
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
        }

        // POST: Groceries/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(GrocerieViewModel model)
        {
            try
            {
                using (var dbContext = new DAL.Context.DatabaseContext())
                {
                    var GroceriesRepository = new DAL.repository.GroceriesRepository(dbContext);
                    var i = await GroceriesRepository.Find(model.Id);
                    dbContext.Remove(i);
                    await dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View(model);
            }
        }
    }
}