﻿namespace Project.Models
{
    public class UpdateStaffDTO
    {
        public int staffId { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? Phone { get; set; }
    }
}
