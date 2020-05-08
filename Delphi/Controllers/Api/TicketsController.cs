﻿using AutoMapper;
using Delphi.Dtos;
using Delphi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace Delphi.Controllers.Api
{
    public class TicketsController : ApiController
    {
        private ApplicationDbContext _context;
        public TicketsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<TicketDto> GetTickets()
        {
            return _context.Tickets
                .Include(c => c.Client)
                .Include(c => c.TicketType)
                .ToList()
                .Select(Mapper.Map<Ticket, TicketDto>);
        }

        public IHttpActionResult GetTicket(int id)
        {
            var ticket = _context.Tickets.SingleOrDefault(c => c.Id == id);

            if (ticket == null)
                NotFound();

            return Ok(Mapper.Map<Ticket, TicketDto>(ticket));
        }

        [HttpPost]
        public IHttpActionResult CreateTicket(TicketDto ticketDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ticket = Mapper.Map<TicketDto, Ticket>(ticketDto);

            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            ticketDto.Id = ticket.Id;

            return Created(new Uri(Request.RequestUri + "/" + ticket.Id), ticketDto);
        }

        [HttpPut]
        public void UpdateTicket(int id, TicketDto ticketDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var ticketInDb = _context.Tickets.SingleOrDefault(c => c.Id == id);

            if (ticketInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(ticketDto, ticketInDb);

            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteTicket(int id)
        {
            var ticketInDb = _context.Tickets.SingleOrDefault(c => c.Id == id);

            if (ticketInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Tickets.Remove(ticketInDb);
            _context.SaveChanges();
        }
    }
}
