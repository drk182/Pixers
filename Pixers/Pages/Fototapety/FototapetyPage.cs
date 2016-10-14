using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Pixers.Core;

namespace Pixers.Pages.Fototapety
{
    public class FototapetyPage : PixersPage
    {
        private By _firstFindProductOnList = By.CssSelector("#tab-products > ul > li:nth-child(1)");

        private static By _productDiv = By.ClassName("product");

        public FototapetyPage() : base(Instance)
        {
        }

        public FototapetyPage SearchFototapeta()
        {
            const string url = "szukaj";

            SearchInPixers(Configuration.GetFototapeta);
            WaitUntilUrlContains(url);

            return this;
        }

        public FototapetyPage ClickOnFirstFindProduct()
        {
            Click(_firstFindProductOnList);

            return this;
        }

        public static bool IsProductDisplayed()
        {
            var product = FindElement(_productDiv);

            return product.Displayed;
        }
    }
}
