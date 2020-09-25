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

        public ActionResult Create()
        {
            return View();
        }

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


        private ArtService CreateArtService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ArtService(userId);
            return service;
        }
    }
   
}