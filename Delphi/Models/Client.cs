﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Delphi.Models
{
    public class Client
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Contact { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
        public int PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }
        public Status Status { get; set; }

        [Display(Name = "Status")]
        public byte StatusId { get; set; }

    }
}