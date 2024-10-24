namespace LeadManager.Domain.DomainObjects
{
    public class LeadLog
    {
        public int LogID { get; set; }
        public int LeadID { get; set; }
        public string? Status { get; set; } // Values: "Accepted", "Declined"
        public decimal PriceApplied { get; set; }
        public decimal? DiscountApplied { get; set; } // Optional, % discount applied
        public DateTime ActionDate { get; set; } = DateTime.Now;
        public bool NotificationSent { get; set; }

        // Navigation properties
        public Lead Lead { get; set; }
    }
}
