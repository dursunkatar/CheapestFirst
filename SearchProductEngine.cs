using EnUcuzUrun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnUcuzUrun
{
    public static class SearchProductEngine
    {
        public static void Search(string baseUrl, string searchPath, string marketName, string marketLogoUrl, Dictionary<string, CssSelectorOption> cssSelectors, List<Product> products)
        {
            string htmlContent = WebRequestEngine.Get(baseUrl + searchPath);
            var htmlParser = new HtmlParser(marketName, marketLogoUrl, cssSelectors, baseUrl);
            products.AddRange(htmlParser.Parse(htmlContent));
        }
    }
}
