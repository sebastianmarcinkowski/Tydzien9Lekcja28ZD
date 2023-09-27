using System;
using InvoiceManager.Models.Domains;
using InvoiceManager.Models.Repositories;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace InvoiceManager.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        private ClientRepository _clientRepository = new ClientRepository();
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var clients = _clientRepository.GetClients(userId);

            return View(clients);
        }

        public ActionResult Client(int id = 0)
        {
            var userId = User.Identity.GetUserId();

            var client =
                id == 0
                    ? GetNewClient(userId)
                    : _clientRepository.GetClient(id, userId);

            ViewBag.Title =
                id == 0
                    ? "Dodawanie nowego klienta"
                    : "Edycja klienta";

            return View(client);
        }

        private Client GetNewClient(string userId)
        {
            return new Client
            {
                UserId = userId,
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Client(Client client)
        {
            var userId = User.Identity.GetUserId();
            client.UserId = userId;

            if (!ModelState.IsValid)
            {
                ViewBag.Title =
                    client.Id == 0
                        ? "Dodawanie nowego klienta"
                        : "Edycja klienta";

                return View("Client", client);
            }

            if (client.Id == 0)
                _clientRepository.Add(client);
            else
                _clientRepository.Update(client);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                _clientRepository.Delete(id, userId);
            }
            catch (Exception exception)
            {
                // Logowanie.
                return Json(new { Success = false, Message = exception.Message });
            }

            return Json(new { Success = true });
        }
    }
}