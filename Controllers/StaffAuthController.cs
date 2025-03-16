using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models.Entities;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffAuthController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public StaffAuthController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost("register")]
        public IActionResult Register(StaffDto Dto)
        {
            if (dbContext.stas.Any(a => a.Email == Dto.Email))
            {
                return BadRequest("Email already exists.");
            }

            var stas = new sta
            {
                Email = Dto.Email,
                Password = Dto.Password // Ideally, hash the password before saving.
            };

            dbContext.stas.Add(stas);
            dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost("login")]
        public IActionResult Login(StaffDto Dto)
        {
            var staff = dbContext.stas.FirstOrDefault(a => a.Email == Dto.Email && a.Password == Dto.Password);

            if (staff == null)
            {
                return Unauthorized("Invalid credentials.");
            }

            return Ok("Login successful.");
        }
    }
}

