using System;
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
    public class StoresController : Controller
    {
        // GET: Stores
        public async Task<ActionResult> Index()
        {
            var viewModel = new List<DAL.Models.Stores>();

            using (var dbContext = new DAL.Context.DatabaseContext())
            {
                var StoresRepository = new DAL.repository.StoresRepository(dbContext);

                viewModel = (await StoresRepository.GetAll()).ToList();
                ViewData["Message"] = "All the storage is on this page (well it needs to be).";
            }
            return View(viewModel);
        }

        // GET: Stores/Details/5
        public async Task<IActionResult> Details(int id)
        {
            using (var dbContext = new DAL.Context.DatabaseContext())
            {
                var StoresRepository = new DAL.repository.StoresRepository(dbContext);
                var store = await StoresRepository.Find(id);
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
                using (var dbContext = new DAL.Context.DatabaseContext())
                {
                    var StoresRepository = new DAL.repository.StoresRepository(dbContext);
                    var Store = new Stores();
                    Store.Openinghours = model.Openinghours;
                    Store.Closinghours = model.Closinghours;
                    Store.StoreName = model.StoreName;
                    Store.StoreLocation = model.StoreLocation;
                    StoresRepository.Add(Store);
                    return RedirectToAction(nameof(Index));
                }
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
                var StoresRepository = new DAL.repository.StoresRepository(dbContext);
                var store = await StoresRepository.Find(id);
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
                using (var dbContext = new DAL.Context.DatabaseContext())
                {
                    var StoresRepository = new DAL.repository.StoresRepository(dbContext);
                    var store = await StoresRepository.Find(model.Id);
                    store.Openinghours = model.Openinghours;
                    store.Closinghours = model.Closinghours;
                    store.StoreName = model.StoreName;
                    store.StoreLocation = model.StoreLocation;
                    await dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
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
            using (var dbContext = new DAL.Context.DatabaseContext())
            {
                var StoresRepository = new DAL.repository.StoresRepository(dbContext);
                var store = await StoresRepository.Find(id);
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

        // POST: Stores/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(StoreViewModel model)
        {
            try
            {
                using (var dbContext = new DAL.Context.DatabaseContext())
                {
                    var StoresRepository = new DAL.repository.StoresRepository(dbContext);
                    var i = await StoresRepository.Find(model.Id);
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