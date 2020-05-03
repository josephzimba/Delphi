using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Delphi.Dtos
{
    public class ClientDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Contact { get; set; }

        
        [Required]
        public int PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public byte StatusId { get; set; }
    }
}