﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Delphi.Dtos
{
    public class StaffDto
    {
        [Required]
        public int Id { get; set; }

        
        [Required]
        public string FirstName { get; set; }

        
        [Required]
        public string LastName { get; set; }

        
        [Required]
        public int PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }
        public int SIN { get; set; }
        public string Occupation { get; set; }
    }
}