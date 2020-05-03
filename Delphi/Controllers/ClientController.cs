using Delphi.Models;
using Delphi.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Delphi.Controllers
{
    public class ClientController : Controller
    {
        private ApplicationDbContext _context;
        public ClientController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Client
        public ViewResult Index()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            var clients = _context.Clients.SingleOrDefault(c => c.Id == id);
            if (clients == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(clients);
            }
        }
        public ActionResult New()
        {
            var status = _context.Status.ToList();
            var viewModel = new ClientFormViewModel
            {
                Status = status
            };
            return View("ClientForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Client client)
        {
            if (!ModelState.IsValid)
            {
                var status = _context.Status.ToList();
                var viewModel = new ClientFormViewModel
                {
                    Client = client,
                    Status = status

                };

                return View("StaffForm", viewModel);
            }
            if (client.Id == 0)
            {
                _context.Clients.Add(client);
            }
            else
            {
                var clientInDb = _context.Clients.Single(c => c.Id == client.Id);

                clientInDb.Address = client.Address;
                clientInDb.Name = client.Name;
                clientInDb.StatusId = client.StatusId;
                clientInDb.PhoneNumber = client.PhoneNumber;
                clientInDb.Contact = client.Contact;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Client");
        }
        public ActionResult Edit(int id)
        {
            var client = _context.Clients.SingleOrDefault(c => c.Id == id);
            if (client == null)
                return HttpNotFound();

            var viewModel = new ClientFormViewModel
            {
                Client = client,
                Status = _context.Status.ToList()
            };

            return View("ClientForm", viewModel);
        }
            
    }
}