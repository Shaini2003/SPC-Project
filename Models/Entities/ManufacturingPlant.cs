using System.ComponentModel.DataAnnotations;

namespace Project.Models.Entities
{
    public class ManufacturingPlant
    {
        [Key]
        public int PlantId { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
    }
}
