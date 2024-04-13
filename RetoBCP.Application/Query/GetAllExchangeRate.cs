using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RetoBCP.Application.Core;
using RetoBCP.Application.DTO;
using RetoBCP.Domain;

namespace RetoBCP.Application.Query
{
    public class GetAllExchangeRate
    {
        public class Query : IRequest<Result<List<GetAllExchangeRateResponse>>>
        {
            public int? Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<List<GetAllExchangeRateResponse>>>
        {
            private readonly ExchangeRateDbContext _context;
            private readonly IMapper _mapper;
            public Handler(ExchangeRateDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<GetAllExchangeRateResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                List<GetAllExchangeRateResponse> result = new List<GetAllExchangeRateResponse>();
                if (request != null)
                {
                    if (request.Id != null)
                    {
                        GetAllExchangeRateResponse exchangeRate = new GetAllExchangeRateResponse();
                        var obj = _context.ExchangeRates.Where(e => e.Id == request.Id).FirstOrDefault();
                        if (obj != null)
                        {
                            exchangeRate = _mapper.Map<ExchangeRate, GetAllExchangeRateResponse>(obj);
                            result.Add(exchangeRate);
                        }
                    }
                    else
                    {
                        var obj = await _context.ExchangeRates.ToListAsync();
                        if (obj != null)
                        {
                            result= _mapper.Map<List<ExchangeRate>, List<GetAllExchangeRateResponse>>(obj);                            
                        }
                    }
                }
                return Result<List<GetAllExchangeRateResponse>>.Success(result);
            }
        }
    }
}
