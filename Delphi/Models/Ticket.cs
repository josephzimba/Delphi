using Delphi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Delphi.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public TicketType TicketType { get; set; }
        public byte TicketTypeId { get; set; }
    }
}