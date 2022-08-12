using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RetoBCP.Application.Core;
using RetoBCP.Application.DTO;
using RetoBCP.Domain;

namespace RetoBCP.Application.Command
{
    public class UpdateExchangeRate
    {
        public class Command : IRequest<Result<UpdateExchangeRateResponse>>
        {
            public UpdateExchangeRateRequest? Dto { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<UpdateExchangeRateResponse>>
        {
            private readonly ExchangeRateDbContext _context;
            private readonly IMapper _mapper;
            public Handler(ExchangeRateDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<UpdateExchangeRateResponse>> Handle(Command request, CancellationToken cancellationToken)
            {
                if (request != null && request.Dto != null)
                {
                    List<ExchangeRate> ExchangeRateActual = new List<ExchangeRate>();
                    ExchangeRateActual = await _context.ExchangeRates.Where(e => e.IsActive && e.ExchangeRateType == request.Dto.ExchangeRateType).ToListAsync();
                    ExchangeRateActual.ForEach(item =>
                    {
                        item.IsActive = false;
                        item.UpdatedOn = DateTime.Now;

                    });
                    _context.ExchangeRates.UpdateRange(ExchangeRateActual);
                    ExchangeRate dto = new ExchangeRate(request.Dto.ExchangeRate, request.Dto.ExchangeRateType);
                    await _context.ExchangeRates.AddAsync(dto);
                    _context.SaveChanges();
                    return Result<UpdateExchangeRateResponse>.Success(_mapper.Map<ExchangeRate, UpdateExchangeRateResponse>(dto));
                }
                throw new InvalidOperationException();
            }
        }

    }
}
