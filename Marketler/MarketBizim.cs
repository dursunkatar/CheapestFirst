using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnUcuzUrun.Marketler
{
    public class MarketBizim : Market
    {
        public MarketBizim()
        {
            Name = "Bizim Market";
            BaseUrl = "https://www.bizimtoptan.com.tr";
            LogoUrl = "https://www.bizimtoptan.com.tr/Themes/BizimToptan/Content/_images/bizimtoptan-logo.svg";
            SearchPath = "/search?q={0}";
            CssSelectors = new(3);
            init();
        }

        private void init()
        {
            CssSelectors.Add("product-images", new CssSelectorOption
            {
                Selector = "img.product-box-zoom-image.d-block.w-100",
                TagAttribute = "src"
            });

            CssSelectors.Add("product-names", new CssSelectorOption
            {
                Selector = "h2.productbox-name.text-center.my-2"
            });

            CssSelectors.Add("product-prices", new CssSelectorOption
            {
                Selector = "div.product-box-container.border a.p-2.d-block p.product-price"
            });
        }
    }
}
