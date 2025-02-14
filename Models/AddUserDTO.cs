namespace Project.Models
{
    public class AddUserDTO
    {
        public int userId { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? Phone { get; set; }
    }
}
