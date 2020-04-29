using Delphi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Delphi.ViewModel
{
    public class ClientEngagementViewModel
    {
        public Client Company { get; set; }
        public List<Staff> Staff { get; set; }
    }
}