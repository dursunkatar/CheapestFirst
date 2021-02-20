using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnUcuzUrun.Marketler
{
    public class MarketMopas : Market
    {
        public MarketMopas()
        {
            Name = "Mopaş";
            BaseUrl = "https://mopas.com.tr";
            LogoUrl = "https://cdngeneral.mopas.com.tr/mopascdncontainer/mopasStaticImages/siteImages/logo.png";
            SearchPath = "/search/?text={0}";
            CssSelectors = new(3);
            init();
        }

        private void init()
        {
            CssSelectors.Add("product-images", new CssSelectorOption
            {
                Selector = "div.container-fluid.product-list-grid div.card a div.image img",
                TagAttribute = "src"
            });

            CssSelectors.Add("product-names", new CssSelectorOption
            {
                Selector = "div.container-fluid.product-list-grid div.card div.content div.title a.product-title"
            });

            CssSelectors.Add("product-prices", new CssSelectorOption
            {
                Selector = "div.container-fluid.product-list-grid div.card div.footer div.product-price span.sale-price"
            });
        }
    }
}
