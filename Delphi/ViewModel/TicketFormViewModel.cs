using Delphi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace Delphi.ViewModel
{
    public class TicketFormViewModel
    {
        public IEnumerable<Client> Client { get; set; }
        public IEnumerable<TicketType> TicketType { get; set; }
        public Ticket Ticket { get; set; }


    }
}