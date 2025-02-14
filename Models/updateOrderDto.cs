using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class updateOrderDto
    {
        public int OrderId { get; set; }

        [Required]
        public int DrugId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    }
}
