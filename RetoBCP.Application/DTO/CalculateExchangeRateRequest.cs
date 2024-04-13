namespace RetoBCP.Application.DTO
{
    public class CalculateExchangeRateRequest
    {
        public string? BuyOrSellType { get; set; }
        public decimal Amount { get; set; }
        public string? OriginCurrency { get; set; }
        public string? FinalCurrency { get; set; }
    }
}