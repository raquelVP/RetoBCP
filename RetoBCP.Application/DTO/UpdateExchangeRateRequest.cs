using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetoBCP.Application.DTO
{
    public class UpdateExchangeRateRequest
    {
        public string? ExchangeRateType { get; set; }
        public decimal ExchangeRate { get; set; }
    }
}
