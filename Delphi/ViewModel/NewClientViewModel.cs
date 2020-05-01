using Delphi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace Delphi.ViewModel
{
    public class NewClientViewModel
    {
        public IEnumerable<Status> Status { get; set; }
        public Client Client { get; set; }
    }
}