using Delphi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Delphi.Controllers
{
    public class StaffController : Controller
    {
        private ApplicationDbContext _context;
        public StaffController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Staff
        public ActionResult Index()
        {
            var staffs = _context.Staffs.ToList();
            return View(staffs);
        }
        public ActionResult Details(int id)
        {
            var staffs = _context.Staffs.SingleOrDefault(c => c.Id == id);
            if (staffs == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(staffs);
            }
        }
        public ActionResult New()
        {
            return View("StaffForm");
        }
        [HttpPost]
        public ActionResult Save(Staff staff)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new Staff();

                return View("StaffForm", viewModel);
            }

            if (staff.Id == 0)
            {
                _context.Staffs.Add(staff);
            }
            else
            {
                var staffInDb = _context.Staffs.Single(c => c.Id == staff.Id);

                staffInDb.Address = staff.Address;
                staffInDb.FirstName = staff.FirstName;
                staffInDb.LastName = staff.LastName;
                staffInDb.Occupation = staff.Occupation;
                staffInDb.PhoneNumber = staff.PhoneNumber;
                staffInDb.SIN = staff.SIN;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Staff");
        }
        public ActionResult Edit(int id)
        {
            var staffs = _context.Staffs.SingleOrDefault(c => c.Id == id);
            if (staffs == null)
                return HttpNotFound();

            var viewModel = new Staff();
            
            return View("StaffForm", viewModel);
        }
    }
}