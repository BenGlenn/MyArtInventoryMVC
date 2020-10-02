using Microsoft.AspNet.Identity;
using MyArt.Model;
using MyArt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyArtInventoryMVC.Controllers
{
    public class ArtController : Controller
    {
        // GET: ART
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ArtService(userId);
            var model = service.GetArt();
            return View(model);
        }

        public ActionResult ListUnSoldArt()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ArtService(userId);
            var model = service.GetUnSoldArt();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        // NO LONGER NEEDED GOING TO SALE INDEX ////

        //public ActionResult GetTotalSales()
        //{
        //    var userId = Guid.Parse(User.Identity.GetUserId());
        //    var service = new ArtService(userId);
        //    var model = service.GetSoldArt();
        //    return View(model);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArtCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateArtService();

            if (service.CreateArt(model))
            {
                TempData["SaveResult"] = "Your Art was added to your inventory.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Art could not be added.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateArtService();
            var model = svc.GetArtById(id);

            return View(model);
        }
        public ActionResult NoteDetails(int id)
        {
            var svc = CreateArtService();
            var model = svc.GetNoteByArtId(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateArtService();
            var detail = service.GetArtById(id);
            var model =
                new ArtEdit
                {
                    ArtID = detail.ArtID,
                    Title = detail.Title,
                    Style = detail.Style,
                    Medium = detail.Medium,
                    Surface = detail.Surface,
                    Size = detail.Size,
                    Price = detail.Price,
                    Location = detail.Location,
                    Sold = detail.Sold,
                    DateOfCreation = detail.DateOfCreation,
                    Note = detail.Note,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ArtEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ArtID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateArtService();

            if (service.UpdateArt(model))
            {
                TempData["SaveResult"] = "Your Art Information Was Updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Art Was Not UPDATED.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateArtService();
            var model = svc.GetArtById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateArtService();

            service.DeleteArt(id);

            TempData["SaveResult"] = "Your Art was deleted";

            return RedirectToAction("Index");
        }

        private ArtService CreateArtService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ArtService(userId);
            return service;
        }
    }
   
}