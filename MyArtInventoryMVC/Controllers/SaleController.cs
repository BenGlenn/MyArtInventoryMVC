using Microsoft.AspNet.Identity;
using MyArt.Data;
using MyArt.Model;
using MyArt.Services;
using MyArtInventoryMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyArtInventoryMVC.Controllers
{
    public class SaleController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Sale
        public ActionResult Index()
        {
            //List<Sale> saleList = _db.Sales.ToList();
            //List<Sale> orderedList = saleList.OrderBy(prod => prod.ArtID).ToList();
            //return View(orderedList);
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SalesService(userId);
            var model = service.GetSale();
            return View(model);
        }
        public ActionResult Create()
        {
          
            var art = new SelectList(_db.Arts.ToList(), "ArtID", "Title");
            ViewBag.Arts = art;
            var client = new SelectList(_db.Clients.ToList(), "ClientID", "FullName");
            ViewBag.Clients = client;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SaleCreate model)
        {

            if (!ModelState.IsValid) return View(model);

            var service = CreateSaleService();

            if (service.CreateSale(model))
            {
                TempData["SaveResult"] = "Your Sale was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Sale could not be added.");
            return View(model);


        }

        private SalesService CreateSaleService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SalesService(userId);
            return service;
        }
    }
}