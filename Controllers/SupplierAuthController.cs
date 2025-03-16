using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models.Entities;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierAuthController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public SupplierAuthController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost("register")]
        public IActionResult Register(SupplierDto Dto)
        {
            if (dbContext.sups.Any(a => a.Email == Dto.Email))
            {
                return BadRequest("Email already exists.");
            }

            var sups = new sup
            {
                Email = Dto.Email,
                Password = Dto.Password // Ideally, hash the password before saving.
            };

            dbContext.sups.Add(sups);
            dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost("login")]
        public IActionResult Login(SupplierDto Dto)
        {
            var supplier = dbContext.sups.FirstOrDefault(a => a.Email == Dto.Email && a.Password == Dto.Password);

            if (supplier == null)
            {
                return Unauthorized("Invalid credentials.");
            }

            return Ok("Login successful.");
        }
    }
}
