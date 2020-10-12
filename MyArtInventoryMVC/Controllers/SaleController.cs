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
    [Authorize]
    public class SaleController : Controller
    {
       

        // GET: Sale
        public ActionResult Index()
        {
           
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SalesService(userId);
            var model = service.GetSale();
            return View(model);
        }
        public ActionResult Create(int id)
        {
            //VIEW BAG CODE//////
            var userId = Guid.Parse(User.Identity.GetUserId());
            var artService = new ArtService(userId);

            var clientService = new ClientService(userId);

            var clientID = clientService.GetClient();
            var artID = artService.GetUnSoldArt();
            var art = new SelectList(artID, "ArtID", "Title");
            ViewBag.Arts = art;
            var client = new SelectList(clientID, "ClientID", "FullName");
            ViewBag.Clients = client;
            /// VIEW BAG CODE ENDS////


            //var priceGet = new ArtService(userId);
            //var truePrice = priceGet.GetArt();

            //var price = new SelectList(truePrice, "Price");
            //ViewBag.Clients = price;

            return View();


            ///ANDREW CODE ///

            //var userId = Guid.Parse(User.Identity.GetUserId());
            //ArtService art = new ArtService(userId);
            //var service = art.GetArtById(id);
            ////var detail = service.GetArtById(id);

            //ViewBag.Art = CallArtTitle(service);

            //var clientService = new ClientService(userId);
            //var clientID = clientService.GetClient();
            //var client = new SelectList(clientID, "ClientID", "FullName");
            //ViewBag.Clients = client;

            //return View();

            ///ANDREW CODE ///

            //VIEW BAG CODE//////
            //var userId = Guid.Parse(User.Identity.GetUserId());
            //var artService = new ArtService(userId);


            //var artID = artService.GetUnSoldArt();
            //var art = new SelectList(artID, "ArtID", "Title");
            //ViewBag.Arts = art;

            //var art = CallArtTitle();
            //var art = new SelectList(artID, "ArtID", "Title");
            //ViewBag.Arts = art;
            //var client = new SelectList(clientID, "ClientID", "FullName");
            //ViewBag.Clients = client;
            /// VIEW BAG CODE ENDS////


            //var priceGet = new ArtService(userId);
            //var truePrice = priceGet.GetArt();

            //var price = new SelectList(truePrice, "Price");
            //ViewBag.Clients = price;

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
   
        public ActionResult CreateFromArt()
        {
            //VIEW BAG CODE//////
            var userId = Guid.Parse(User.Identity.GetUserId());
            //var artService = new ArtService(userId);

            var clientService = new ClientService(userId);

            var clientID = clientService.GetClient();
            //var artID = artService.GetUnSoldArt();
            //var art = new SelectList(artID, "ArtID", "Title");
            //ViewBag.Arts = art;
            var client = new SelectList(clientID, "ClientID", "FullName");
            ViewBag.Clients = client;
            /// VIEW BAG CODE ENDS////


            //var priceGet = new ArtService(userId);
            //var truePrice = priceGet.GetArt();

            //var price = new SelectList(truePrice, "Price");
            //ViewBag.Clients = price;

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFromArt(SaleCreate model)
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


        public ActionResult Details(int id)
        {
            var svc = CreateSaleService();
            var model = svc.GetSaleByID(id);

            return View(model);
        }

        public ActionResult SaleDirection()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SalesService(userId);

            return View();
        }

        public ActionResult Edit(int id)
        {
            var service = CreateSaleService();
            var detail = service.GetSaleByID(id);
            var model =
                new SaleEdit
                {
                    SaleID = detail.SaleID,
                    //ArtID = detail.ArtID,
                    //ClientID = detail.ClientID,
                    Title = detail.Title,
                   Location = detail.Location,
                   Price = detail.Price,
                   SellingPrice = detail.SellingPrice,
                   VenderCommission = detail.VenderCommission,
                   DateOfTransaction = detail.DateOfTransaction,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SaleEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SaleID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateSaleService();

            if (service.UpdateSale(model))
            {
                TempData["SaveResult"] = "Your Sale Information Was Updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Sale Could Not Be UPDATED.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateSaleService();
            var model = svc.GetSaleByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateSaleService();

            service.DeleteSale(id);

            TempData["SaveResult"] = "Your Sale was deleted";

            return RedirectToAction("Index");
        }


        private SalesService CreateSaleService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SalesService(userId);
            return service;
        }

        private SelectList CallArtTitle(ArtDetail detail)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var artService = new ArtService(userId);

            return new SelectList(artService.GetUnSoldArt(), "ArtID", "Title", detail.ArtID);
        }
       
    }
}