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

        private static By _addProductToBasketButton = By.Id("buy-button");

        private static By _goToBasketButton = By.Id("button-to-cart");

        private static By _buySuccess = By.Id("buy_success");

        private static By _basket = By.ClassName("cart");

        public FototapetyPage() : base(Instance)
        {
        }

        public FototapetyPage SearchFototapeta()
        {
            ClosePopUpIfVisible();

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

        public static bool IsBestsellerPage()
        {
            var presentationHeader = FindElement(By.ClassName("content__presentation-header"));

            return presentationHeader.Text.Contains("Bestseller");
        }

        public FototapetyPage AddToBasket()
        {
            WaitForElementClickable(_addProductToBasketButton);
            Click(_addProductToBasketButton);

            return this;
        }


        public FototapetyPage GoToBasket()
        {
            WaitForElementClickable(_goToBasketButton);
            Click(_goToBasketButton);

            return this;
        }

        public int ProductQuantityInBasket()
        {
            var row = By.ClassName("cart_middle");
            var rowCount = Instance.FindElements(row).Count - 1;

            return rowCount;
        }
    }
}
