using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models.Entities;
using Project.Models;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public StaffController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllStaff()
        {
            var allStaff = dbContext.staff.ToList();
            return Ok(allStaff);
        }

        [HttpGet]
        [Route("{staffId:int}")]

        public IActionResult GetStaffById(int staffId)
        {
            var staff = dbContext.staff.Find(staffId);

            if (staff is null)
            {
                return NotFound();
            }
            return Ok(staff);
        }


        [HttpPost]
        public IActionResult AddStaff(AddStaffDTO addStaffDto)
        {
            var staffEntity = new Staff()
            {
                staffId = addStaffDto.staffId,
                Name=addStaffDto.Name,
                Email=addStaffDto.Email,
                Password=addStaffDto.Password,
                Phone=addStaffDto.Phone,
                
            };
            dbContext.staff.Add(staffEntity);
            dbContext.SaveChanges();

            return Ok(staffEntity);
        }

        [HttpPut]
        public IActionResult UpdateStaff(int staffId, UpdateStaffDTO updatestaffDto)
        {
            var staff = dbContext.staff.Find(staffId);
            if (staff is null)
            {
                return NotFound();
            }

            staff.staffId = updatestaffDto.staffId;
            staff.Name = updatestaffDto.Name;
            staff.Email = updatestaffDto.Email;
            staff.Password = updatestaffDto.Password;
            staff.Phone = updatestaffDto.Phone;
            



            dbContext.SaveChanges();

            return Ok(staff);
        }
        [HttpDelete]
        [Route("{staffId:int}")]
        public IActionResult DeleteStaff(int staffId)
        {
            var staff = dbContext.staff.Find(staffId);
            if (staff is null)
            {
                return NotFound();
            }
            dbContext.staff.Remove(staff);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
