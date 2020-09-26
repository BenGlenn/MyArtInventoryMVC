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
            List<Sale> saleList = _db.Sales.ToList();
            List<Sale> orderedList = saleList.OrderBy(prod => prod.ArtID).ToList();
            return View(orderedList);
        }
        public ActionResult Create()
        {
            var client = new SelectList(_db.Clients.ToList(), "ClientID", "FullName");
            ViewBag.Clients = client;
            var art = new SelectList(_db.Arts.ToList(), "ArtID", "Title");
            ViewBag.Arts = art;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SaleCreate sale)
        {
            if (ModelState.IsValid)
            {
                Client client = _db.Clients.Find(sale.ClientID);
                if (client == null)
                    return HttpNotFound();

                Art art = _db.Arts.Find(sale.ArtID);
                if (art == null)
                    return HttpNotFound();

                //_db.Sales.Add(sale);
              
                //_db.SaveChanges();
                //return RedirectToAction("Index");
            }
            return View(sale);
        }

        private SalesService CreateSaleService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SalesService(userId);
            return service;
        }
    }
}