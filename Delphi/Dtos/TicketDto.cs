using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Delphi.Dtos
{
    public class TicketDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public byte TicketTypeId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateClosed { get; set; }

        [Required]
        public int ContractPrice { get; set; }

        [Required]
        public int ClientId { get; set; }
    }
}