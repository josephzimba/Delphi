using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Delphi.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public int SIN { get; set; }
    }
}