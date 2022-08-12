using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetoBCP.Domain
{
    public class ExchangeRate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal AmountExchangeRate { get; set; }
        public string? ExchangeRateType { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public ExchangeRate(decimal amountExchangeRate, string? exchangeRateType)
        {
            AmountExchangeRate = amountExchangeRate;
            CreatedOn = DateTime.Now;
            IsActive = true;
            ExchangeRateType = exchangeRateType;
        }
    }
}