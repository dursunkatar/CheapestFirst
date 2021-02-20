using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnUcuzUrun.Marketler
{
    public class MarketA101 : Market
    {
        public MarketA101()
        {
            Name = "A101";
            BaseUrl = "https://www.a101.com.tr";
            LogoUrl = "https://ayb.akinoncdn.com/static_omnishop/ayb607/assets/img/logo%40a101-2x.png";
            SearchPath = "/list/?search_text={0}&personaclick_search_query={0}&personaclick_input_query={0}";
            CssSelectors = new(3);
            init();
        }

        private void init()
        {
            CssSelectors.Add("product-images", new CssSelectorOption
            {
                Selector = "div.product-actions a div.product-image img",
                TagAttribute = "data-src"
            });

            CssSelectors.Add("product-names", new CssSelectorOption
            {
                Selector = "a.name-price div.product-desc h3.name"
            });

            CssSelectors.Add("product-prices", new CssSelectorOption
            {
                Selector = "div.product-actions div.add-basket.js-add-basket-area div.price"
            });
        }
    }
}
