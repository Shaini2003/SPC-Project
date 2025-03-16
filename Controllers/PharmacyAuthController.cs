using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models.Entities;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyAuthController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public PharmacyAuthController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost("register")]
        public IActionResult Register(PharmacyDto Dto)
        {
            if (dbContext.pharmas.Any(a => a.Email == Dto.Email))
            {
                return BadRequest("Email already exists.");
            }

            var pharmas = new pharma
            {
                Email = Dto.Email,
                Password = Dto.Password // Ideally, hash the password before saving.
            };

            dbContext.pharmas.Add(pharmas);
            dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost("login")]
        public IActionResult Login(PharmacyDto Dto)
        {
            var pharmacy = dbContext.pharmas.FirstOrDefault(a => a.Email == Dto.Email && a.Password == Dto.Password);

            if (pharmacy == null)
            {
                return Unauthorized("Invalid credentials.");
            }

            return Ok("Login successful.");
        }
    }
}

