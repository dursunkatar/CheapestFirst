using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnUcuzUrun.Models
{
    public class HomeViewModel
    {
        public IEnumerable<string> LogoUrls { get; set; }
        public List<Product> Products { get; set; }
    }
}
