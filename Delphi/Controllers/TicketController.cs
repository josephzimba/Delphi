using Delphi.Models;
using Delphi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Delphi.Controllers
{
    public class TicketController : Controller
    {
        private ApplicationDbContext _context;
        public TicketController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Ticket
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            var ticketType = _context.TicketTypes.ToList();
            var client = _context.Clients.ToList();
            var viewModel = new TicketFormViewModel
            {
                Client = client,
                TicketType = ticketType
            };
            return View("TicketForm", viewModel);
        }
    }
}