using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Delphi.Models
{
    public class Staff
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }

        [DisplayName("Phone Number")]
        [Required]
        public int PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }
        public int SIN { get; set; }
        public string Occupation { get; set; }
    }
}