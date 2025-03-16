using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models.Entities;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminAuthController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public AdminAuthController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost("register")]
        public IActionResult Register(AdminDto adminDto)
        {
            if (dbContext.Adminns.Any(a => a.Email == adminDto.Email))
            {
                return BadRequest("Email already exists.");
            }

            var Adminns = new Admi
            {
                Email = adminDto.Email,
                Password = adminDto.Password // Ideally, hash the password before saving.
            };

            dbContext.Adminns.Add(Adminns);
            dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost("login")]
        public IActionResult Login(AdminDto adminDto)
        {
            var admin = dbContext.Adminns.FirstOrDefault(a => a.Email == adminDto.Email && a.Password == adminDto.Password);

            if (admin == null)
            {
                return Unauthorized("Invalid credentials.");
            }

            return Ok("Login successful.");
        }
    }
}
