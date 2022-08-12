namespace RetoBCP.Application.DTO
{
    public class CalculateExchangeRateResponse
    {
        public decimal Amount { get; set; }
        public decimal AmounExchangeRate { get; set; }
        public string? OriginCurrency { get; set; }
        public string? FinalCurrency { get; set; }
        public decimal ExchangeRate { get; set; }
    }
}