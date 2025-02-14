using System.ComponentModel.DataAnnotations;

namespace Project.Models.Entities
{
    public class Pharmacy
    {
        [Key]
        public int PharmacyID { get; set; }
        public string PharmacyName { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string LinkedStatus { get; set; }
    }
}
