using EnUcuzUrun.Marketler;
using EnUcuzUrun.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnUcuzUrun.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = new HomeViewModel()
            {
                LogoUrls = Utilities.MarketLogoUrls,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string product)
        {
            var model = new HomeViewModel()
            {
                LogoUrls = Utilities.MarketLogoUrls,
                Products = new List<Product>()
            };

            List<Market> markets = new()
            {
                new MarketA101 { SearchText = product },
                new MarketBizim { SearchText = product },
                new MarketCagri { SearchText = product },
                new MarketHakmar { SearchText = product },
                new MarketMopas { SearchText = product },
                new MarketHappyCenter { SearchText = product }
            };

            List<Task> taskList = markets.Select(market => new Task(market.LoadProducts)).ToList();
            taskList.ForEach(t => t.Start());

            await Task.WhenAll(taskList);

            markets.ForEach(market => model.Products.AddRange(market.Products));

            return View(model);
        }
    }
}
