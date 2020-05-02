using Delphi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace Delphi.ViewModel
{
    public class ClientEngagementViewModel
    {
        public IEnumerable<Client> Client { get; set; }
        public IEnumerable<Staff> Staff { get; set; }
              
        
    }
}