using EnUcuzUrun.Models;
using System.Collections.Generic;

namespace EnUcuzUrun.Marketler
{
    public abstract class Market
    {
        protected string Name { get; init; }
        public string BaseUrl { get; init; }
        protected string LogoUrl { get; init; }
        protected string SearchPath { get; init; }
        protected Dictionary<string, CssSelectorOption> CssSelectors { get; init; }
        public string SearchText { protected get; init; }
        public List<Product> Products { get; } = new();
        public virtual void LoadProducts() => SearchProductEngine.Search(BaseUrl , string.Format(SearchPath, SearchText), Name, LogoUrl, CssSelectors, Products);
    }
}
