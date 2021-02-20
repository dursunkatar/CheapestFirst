using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnUcuzUrun.Marketler
{
    public class MarketCagri : Market
    {
        public MarketCagri()
        {
            Name = "Çağrı Market";
            BaseUrl = "https://www.cagri.com";
            LogoUrl = "https://www.cagri.com/Uploads/EditorUploads/logo.png";
            SearchPath = "/Arama?1&kelime={0}";
            CssSelectors = new(3);
            init();
        }

        private void init()
        {
            CssSelectors.Add("product-images", new CssSelectorOption
            {
                Selector = "div.productImage a.detailLink.detailUrl img.resimOrginal",
                TagAttribute = "data-original"
            });

            CssSelectors.Add("product-names", new CssSelectorOption
            {
                Selector = "div.productDetail.videoAutoPlay div.productName.detailUrl a"
            });

            CssSelectors.Add("product-prices", new CssSelectorOption
            {
                Selector = "div.productDetail.videoAutoPlay div.productPrice div.discountPrice span"
            });
        }
    }
}
