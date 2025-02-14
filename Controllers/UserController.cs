using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models.Entities;
using Project.Models;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public UserController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var allUsers = dbContext.Users.ToList();
            return Ok(allUsers);
        }

        [HttpGet]
        [Route("{userId:int}")]

        public IActionResult GetUserById(int UserID)
        {
            var user = dbContext.Users.Find(UserID);

            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpPost]
        public IActionResult AddUser(AddUserDTO addUserDto)
        {
            var userEntity = new User()
            {
                userId = addUserDto.userId,
                Name=addUserDto.Name,
                Email=addUserDto.Email,
                Password=addUserDto.Password,
                Phone=addUserDto.Phone,
               
            };
            dbContext.Users.Add(userEntity);
            dbContext.SaveChanges();

            return Ok(userEntity);
        }

        [HttpPut]
        public IActionResult UpdateUser(int userId, UpdateUserDTO updateuserDto)
        {
            var user = dbContext.Users.Find(userId);
            if (user is null)
            {
                return NotFound();
            }

            user.userId = updateuserDto.userId;
            user.Name = updateuserDto.Name;
            user.Email = updateuserDto.Email;
            user.Password = updateuserDto.Password;
            user.Phone = updateuserDto.Phone;
            



            dbContext.SaveChanges();

            return Ok(user);
        }
        [HttpDelete]
        [Route("{userId:int}")]
        public IActionResult DeleteUser(int userId)
        {
            var user = dbContext.Users.Find(userId);
            if (user is null)
            {
                return NotFound();
            }
            dbContext.Users.Remove(user);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
