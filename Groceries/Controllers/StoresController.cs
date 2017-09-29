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
    public class StoresController : Controller
    {
        private IRepository<Stores> StoresRepository { get; set; }

        public StoresController(IRepository<DAL.Models.Stores> storesRepository)
        {
            StoresRepository = storesRepository;
        }

        // GET: Stores
        public async Task<IActionResult> Index()
        {
            var viewModel = (await StoresRepository.GetAllAsync()).Select(x => new StoreViewModel
            {
                Id = x.Id,
                Openinghours = x.Openinghours,
                Closinghours = x.Closinghours,
                StoreName = x.StoreName,
                StoreLocation = x.StoreLocation
            }).ToList();
            return View(viewModel);
        }

        // GET: Stores/Details/5
        public async Task<IActionResult> Details(int id)
        {
                var store = await StoresRepository.FindAsync(id);
                if (store == null) return RedirectToAction(nameof(Index));
                return View(new StoreViewModel
                {
                    Id = store.Id,
                    Openinghours = store.Openinghours,
                    Closinghours = store.Closinghours,
                    StoreName = store.StoreName,
                    StoreLocation = store.StoreLocation
                });
        }

        // GET: Stores/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StoreViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please check fields for errer");
                return View(model);
            }
            try
            {
                var Store = new Stores
                {
                    Openinghours = model.Openinghours,
                    Closinghours = model.Closinghours,
                    StoreName = model.StoreName,
                    StoreLocation = model.StoreLocation
                };
                StoresRepository.AddAsync(Store);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Stores/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            using (var dbContext = new DAL.Context.DatabaseContext())
            {
                var StoresRepository = new DAL.Repositories.StoresRepository(dbContext);
                var store = await StoresRepository.FindAsync(id);
                if (store == null) return RedirectToAction(nameof(Index));
                return View(new StoreViewModel
                {
                    Id = store.Id,
                    Openinghours = store.Openinghours,
                    Closinghours = store.Closinghours,
                    StoreName = store.StoreName,
                    StoreLocation = store.StoreLocation
                });
            }
        }

        // Post: Stores/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(StoreViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please check fields for errer");
                return View(model);
            }
            try
            {
                    var store = await StoresRepository.FindAsync(model.Id);
                    store.Openinghours = model.Openinghours;
                    store.Closinghours = model.Closinghours;
                    store.StoreName = model.StoreName;
                    store.StoreLocation = model.StoreLocation;
                    await StoresRepository.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Stores/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
                var store = await StoresRepository.FindAsync(id);
                if (store == null) return RedirectToAction(nameof(Index));
                return View(new StoreViewModel
                {
                    Id = store.Id,
                    Openinghours = store.Openinghours,
                    Closinghours = store.Closinghours,
                    StoreName = store.StoreName,
                    StoreLocation = store.StoreLocation
                });
        }

        // POST: Stores/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(StoreViewModel model)
        {
            try
            {
                    StoresRepository.Remove(model.Id);
                    await StoresRepository.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));            }
            catch
            {
                return View(model);
            }
        }
    }
}