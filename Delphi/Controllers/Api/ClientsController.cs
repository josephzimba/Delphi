using AutoMapper;
using Delphi.Dtos;
using Delphi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;

namespace Delphi.Controllers.Api
{
    public class ClientsController : ApiController
    {
        private ApplicationDbContext _context;
        public ClientsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<ClientDto> GetClients()
        {
            return _context.Clients.ToList().Select(Mapper.Map<Client, ClientDto>);
        }

        public IHttpActionResult GetClient(int id)
        {
            var client = _context.Clients.SingleOrDefault(c => c.Id == id);

            if (client == null)
                NotFound();

            return Ok(Mapper.Map<Client, ClientDto>(client));
        }

        [HttpPost]
        public IHttpActionResult CreateClient(ClientDto clientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var client = Mapper.Map<ClientDto, Client>(clientDto);

            _context.Clients.Add(client);
            _context.SaveChanges();

            clientDto.Id = client.Id;

            return Created(new Uri(Request.RequestUri + "/" + client.Id), clientDto);
        }

        [HttpPut]
        public void UpdateClient(int id, ClientDto clientDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var clientInDb = _context.Clients.SingleOrDefault(c => c.Id == id);

            if (clientInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(clientDto, clientInDb);

            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var clientInDb = _context.Clients.SingleOrDefault(c => c.Id == id);

            if (clientInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Clients.Remove(clientInDb);
            _context.SaveChanges();
        }
    }
}
