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
            var ticket = _context.Tickets.Include(c => c.Client).ToList();
            return View(ticket);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Ticket ticket)
        {
            if (!ModelState.IsValid)
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
            if (ticket.Id == 0)
            {
                ticket.DateCreated = DateTime.Now;
                _context.Tickets.Add(ticket);
            }
            else
            {
                var ticketInDb = _context.Tickets.Single(c => c.Id == ticket.Id);

                ticketInDb.ContractPrice = ticket.ContractPrice;
                ticketInDb.DateClosed = ticket.DateClosed;
                ticketInDb.DateCreated = ticket.DateCreated;
                ticketInDb.ClientId = ticket.ClientId;
                ticketInDb.Client = ticket.Client;
                ticketInDb.TicketTypeId = ticket.TicketTypeId;
                ticketInDb.TicketType = ticket.TicketType;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Ticket");
        }
        public ActionResult Edit(int id)
        {
            var ticket = _context.Tickets.SingleOrDefault(c => c.Id == id);
            if (ticket == null)
                return HttpNotFound();

            var viewModel = new TicketFormViewModel
            {
                Ticket = ticket,
                TicketType = _context.TicketTypes.ToList(),
                Client = _context.Clients.ToList()
            };

            return View("TicketForm", viewModel);
        }
    }
}