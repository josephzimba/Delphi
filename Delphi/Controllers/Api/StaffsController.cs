using AutoMapper;
using Delphi.Dtos;
using Delphi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Delphi.Controllers.Api
{
    public class StaffsController : ApiController
    {
        private ApplicationDbContext _context;
        public StaffsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<StaffDto> GetStaffs()
        {
            return _context.Staffs.ToList().Select(Mapper.Map<Staff, StaffDto>);
        }

        public IHttpActionResult GetStaff(int id)
        {
            var staff = _context.Staffs.SingleOrDefault(c => c.Id == id);

            if (staff == null)
                NotFound();

            return Ok(Mapper.Map<Staff, StaffDto>(staff));
        }

        [HttpPost]
        public IHttpActionResult CreateStaff(StaffDto staffDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var staff = Mapper.Map<StaffDto, Staff>(staffDto);

            _context.Staffs.Add(staff);
            _context.SaveChanges();

            staffDto.Id = staff.Id;

            return Created(new Uri(Request.RequestUri + "/" + staff.Id), staffDto);
        }

        [HttpPut]
        public void UpdateClient(int id, StaffDto staffDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var staffInDb = _context.Staffs.SingleOrDefault(c => c.Id == id);

            if (staffInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(staffDto, staffInDb);

            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var staffInDb = _context.Staffs.SingleOrDefault(c => c.Id == id);

            if (staffInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Staffs.Remove(staffInDb);
            _context.SaveChanges();
        }
    }
}
