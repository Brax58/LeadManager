using System.ComponentModel.DataAnnotations;

namespace LeadManager.Domain.Models
{
    public class LeadLog
    {
        [Key]
        public int LogID { get; set; }

        public int LeadID { get; set; }
        public string? Status { get; set; } // Values: "Accepted", "Declined"
        public decimal PriceApplied { get; set; }
        public decimal? DiscountApplied { get; set; }// Optional, % discount applied
        public DateTime ActionDate { get; set; } = DateTime.Now;
        public bool NotificationSent { get; set; }


        public virtual Lead Lead { get; set; }

        public LeadLog()
        { }

        public LeadLog(int leadId,string status,decimal price,decimal discountPrice)
        {
            LeadID = leadId;
            Status = status;
            PriceApplied = price;
            DiscountApplied = discountPrice;
            ActionDate = DateTime.Now;
            NotificationSent = true;
        }
    }
}
