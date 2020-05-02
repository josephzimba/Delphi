using Delphi.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Delphi.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public TicketType TicketType { get; set; }

        [Display(Name = "Ticket Type")]
        public byte TicketTypeId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateClosed { get; set; }

        [Display(Name = "Contract Value")]
        public int ContractPrice { get; set; }
        public Client Client { get; set; }

        [Display(Name ="Company")]
        public int ClientId { get; set; }
    }
}