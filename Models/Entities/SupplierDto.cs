using System.ComponentModel.DataAnnotations;

namespace Project.Models.Entities
{
    public partial class SupplierDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }
    }
}
