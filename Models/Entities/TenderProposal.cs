using System.ComponentModel.DataAnnotations;

namespace Project.Models.Entities
{
    public class TenderProposal
    {
        public int Id { get; set; }

        [Required]
        public string SupplierName { get; set; }

        [Required]
        public string ProposalDetails { get; set; }

        public DateTime SubmittedDate { get; set; } = DateTime.Now;

        public TenderStatus Status { get; set; } = TenderStatus.Pending;
    }

    public enum TenderStatus
    {
        Pending,
        Accepted,
        Rejected
    }
}
