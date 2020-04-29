using Delphi.Models;
using System;
using System.Collections.Generic;
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
            var clients = _context.Clients.ToList();
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
    }
}