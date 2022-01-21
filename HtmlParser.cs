using EnUcuzUrun.Models;
using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using System;
using System.Collections.Generic;

namespace EnUcuzUrun
{
    public class HtmlParser
    {
        private readonly Dictionary<string, CssSelectorOption> _cssSelectors;
        private readonly string _marketName;
        private readonly string _marketLogoUrl;
        private readonly string _marketBaseUrl;

        public HtmlParser(string marketName, string marketLogoUrl, Dictionary<string, CssSelectorOption> cssSelectors, string baseUrl)
        {
            _marketName = marketName;
            _marketLogoUrl = marketLogoUrl;
            _cssSelectors = cssSelectors;
            _marketBaseUrl = baseUrl;
        }

        public List<Product> Parse(string html)
        {
            var doc = new HtmlDocument();
            var products = new List<Product>();
            clearHtml(ref html, "<span class=\"oldprice\">", "</span>");
            clearHtml(ref html, "<span class=\"discountKdv\">", "</span>");
            doc.LoadHtml(html);
            var (imageNodes, nameNodes, priceNodes) = GetNodes(doc);

            if (imageNodes.Count == 0)
            {
                return products;
            }

            for (int i = 0; i < nameNodes.Count; i++)
            {
                products.Add(new Product
                {
                    MarketName = _marketName,
                    MarketBaseUrl = _marketBaseUrl,
                    MarketLogoUrl = _marketLogoUrl,
                    ProductImageUrl = GetProducImageUrlFromNode(imageNodes[i]),
                    ProductName = GetProductNameFromNode(nameNodes[i]),
                    ProductPrice = GetProductPriceFromNode(priceNodes[i])
                });
            }
            return products;
        }

        private (IList<HtmlNode>, IList<HtmlNode>, IList<HtmlNode>) GetNodes(HtmlDocument doc)
        {
            IList<HtmlNode> imageNodes = doc.QuerySelectorAll(_cssSelectors["product-images"].Selector);
            IList<HtmlNode> nameNodes = doc.QuerySelectorAll(_cssSelectors["product-names"].Selector);
            IList<HtmlNode> priceNodes = doc.QuerySelectorAll(_cssSelectors["product-prices"].Selector);
            return (imageNodes, nameNodes, priceNodes);
        }

        private string GetProducImageUrlFromNode(HtmlNode node)
        {
            string img = "";
            try
            {
                if (_cssSelectors["product-images"].TagAttribute is null)
                {
                    img = node.InnerText.Trim();
                }
                else if (node.Attributes[_cssSelectors["product-images"].TagAttribute] != null)
                {
                    img = node.Attributes[_cssSelectors["product-images"].TagAttribute].Value.Trim();
                }
            }
            catch { }
            return img;
        }

        private string GetProductNameFromNode(HtmlNode node) => _cssSelectors["product-names"].TagAttribute is null
                                    ? node.InnerText.Trim()
                                    : node.Attributes[_cssSelectors["product-names"].TagAttribute].Value.Trim();

        private decimal GetProductPriceFromNode(HtmlNode node) => _cssSelectors["product-prices"].TagAttribute is null
                                  ? Convert.ToDecimal(node.InnerText.Replace("TL", "").Replace("₺", "").Trim())
                                  : Convert.ToDecimal(node.Attributes[_cssSelectors["product-prices"].TagAttribute].Value.Replace("TL", "").Trim());

        private void clearHtml(ref string htmlContext, string startPattern, string endPattern)
        {
            int TAG_LENGTH = endPattern.Length;
            do
            {
                int startIndex = htmlContext.IndexOf(startPattern);
                if (startIndex == -1)
                {
                    break;
                }
                int endIndex = htmlContext.IndexOf(endPattern, startIndex);
                var tmpHtml = htmlContext.Substring(startIndex, TAG_LENGTH + endIndex - startIndex);
                htmlContext = htmlContext.Replace(tmpHtml, string.Empty);
            } while (true);
        }
    }
}
