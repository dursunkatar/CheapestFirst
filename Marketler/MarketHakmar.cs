using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnUcuzUrun.Marketler
{
    public class MarketHakmar : Market
    {
        public MarketHakmar()
        {
            Name = "Hakmar";
            BaseUrl = "https://www.hakmarexpress.com.tr";
            LogoUrl = "http://st1.myideasoft.com/idea/el/24/themes/selftpl_5ea0634b2cbf6/assets/uploads/logo.png?revision=1613637921";
            SearchPath = "/arama/{0}";
            CssSelectors = new(3);
            init();
        }

        private void init()
        {
            CssSelectors.Add("product-images", new CssSelectorOption
            {
                Selector = "div.showcase-image a img.lazyload",
                TagAttribute = "data-src"
            });

            CssSelectors.Add("product-names", new CssSelectorOption
            {
                Selector = "div.showcase-content div.showcase-title a"
            });

            CssSelectors.Add("product-prices", new CssSelectorOption
            {
                Selector = "div.showcase-price div.showcase-price-new"
            });
        }
    }
}
