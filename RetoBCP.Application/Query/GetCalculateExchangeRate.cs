using MediatR;
using Microsoft.EntityFrameworkCore;
using RetoBCP.Application.Core;
using RetoBCP.Application.DTO;
using RetoBCP.Domain;

namespace RetoBCP.Application.Query
{
    public class GetCalculateExchangeRate
    {
        public class Query : IRequest<Result<CalculateExchangeRateResponse>>
        {
            public CalculateExchangeRateRequest? Dto { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<CalculateExchangeRateResponse>>
        {
            private readonly ExchangeRateDbContext _context;
            public Handler(ExchangeRateDbContext context)
            {
                _context = context;
            }
            public async Task<Result<CalculateExchangeRateResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                if (request != null && request.Dto != null)
                {
                    var obj = await _context.ExchangeRates.Where(e => e.IsActive && e.ExchangeRateType == request.Dto.BuyOrSellType).FirstOrDefaultAsync();
                    if (obj != null)
                    {
                        
                        CalculateExchangeRateResponse result = new CalculateExchangeRateResponse()
                        {
                            Amount = request.Dto.Amount,
                            AmounExchangeRate = (request.Dto.BuyOrSellType == "BUY" ? request.Dto.Amount * obj.AmountExchangeRate : request.Dto.BuyOrSellType == "SELL" ? request.Dto.Amount / obj.AmountExchangeRate : 0.00M),
                            OriginCurrency = request.Dto.OriginCurrency,
                            FinalCurrency = request.Dto.FinalCurrency,
                            ExchangeRate = obj.AmountExchangeRate
                        };
                        return Result<CalculateExchangeRateResponse>.Success(result);
                    }
                }
                throw new InvalidOperationException();
            }
        }
    }
}
