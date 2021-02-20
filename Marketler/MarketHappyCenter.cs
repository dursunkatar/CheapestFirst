using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnUcuzUrun.Marketler
{
    public class MarketHappyCenter : Market
    {
        public MarketHappyCenter()
        {
            Name = "Happy Center";
            BaseUrl = "https://www.happycenter.com.tr";
            LogoUrl = "https://www.happycenter.com.tr/Content/images/happy-center-logo-web.png";
            SearchPath = "/Product/Search/?ara={0}";
            CssSelectors = new(3);
            init();
        }

        private void init()
        {
            CssSelectors.Add("product-images", new CssSelectorOption
            {
                Selector = "div.col-product.col-md-2.col-sm-4.col-xs-4 a img.img-product.img-responsive",
                TagAttribute = "src"
            });

            CssSelectors.Add("product-names", new CssSelectorOption
            {
                Selector = "div.col-product.col-md-2.col-sm-4.col-xs-4 p a"
            });

            CssSelectors.Add("product-prices", new CssSelectorOption
            {
                Selector = "div.col-product.col-md-2.col-sm-4.col-xs-4 p span"
            });
        }
    }
}
