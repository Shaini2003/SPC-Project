using System.ComponentModel.DataAnnotations;

namespace Project.Models.Entities
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
      
    }
}

