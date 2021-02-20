using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnUcuzUrun.Models
{
    public record Product
    {
        public string MarketName { get; init; }
        public string MarketBaseUrl { get; init; }
        public string MarketLogoUrl { get; init; }
        public string ProductName { get; init; }
        public string ProductImageUrl { get; init; }
        public decimal ProductPrice { get; set; }
    }
}
