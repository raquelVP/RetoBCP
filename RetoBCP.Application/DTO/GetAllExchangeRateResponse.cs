namespace RetoBCP.Application.DTO
{
    public class GetAllExchangeRateResponse
    {
        public int Id { get; set; }
        public decimal AmountExchangeRate { get; set; }
        public string? ExchangeRateType { get; set; }
        public bool IsActive { get; set; }
        public DateTime Date { get; set; }
    }
}
