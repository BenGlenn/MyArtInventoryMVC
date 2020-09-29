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
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClientService(userId);
            var model = service.GetClient();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateClientService();

            if (service.CreateClient(model))
            {
                TempData["SaveResult"] = "Your client was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Client could not be added.");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewSaleCreate(ClientCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateClientService();

            if (service.CreateClient(model))
            {
                TempData["SaveResult"] = "Your client was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Client could not be added.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateClientService();
            var model = svc.GetClientByID(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateClientService();
            var detail = service.GetClientByID(id);
            var model =
                new ClientEdit
                {
                    ClientID = detail.ClientID,
                    Collector = detail.Collector,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClientEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ClientID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateClientService();

            if (service.UpdateClient(model))
            {
                TempData["SaveResult"] = "Your Client Information Was Updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Client Could Not Be UPDATED.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateClientService();
            var model = svc.GetClientByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateClientService();

            service.DeleteClient(id);

            TempData["SaveResult"] = "Your Client was deleted";

            return RedirectToAction("Index");
        }

        private ClientService CreateClientService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClientService(userId);
            return service;
        }
    }
}