namespace RetoBCP.Application.DTO
{
    public class UpdateExchangeRateResponse
    {
        public int Id { get; set; }
        public decimal AmountExchangeRate { get; set; }
        public string? ExchangeRateType { get; set; }
        public DateTime Date { get; set; }
    }
}
