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
            var clients = _context.Clients.Include(c => c.Status).ToList();
            return View(clients);
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
            var viewModel = new NewClientViewModel
            {
                Status = status
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();

            return RedirectToAction("Index", "Client");
        }
    }
}