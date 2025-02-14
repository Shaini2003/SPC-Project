using System.ComponentModel.DataAnnotations;

namespace Project.Models.Entities
{
    public class Staff
    {
        [Key]
        public int staffId { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? Phone { get; set; }
    
}
}
