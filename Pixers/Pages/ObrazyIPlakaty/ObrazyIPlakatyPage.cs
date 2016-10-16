using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Pixers.Pages.ObrazyIPlakaty
{
    public class ObrazyIPlakatyPage : PixersPage
    {
        private static By _materialFilter = By.Id("check-material-1");

        public ObrazyIPlakatyPage() : base(Instance)
        {
        }

        public ObrazyIPlakatyPage CheckMaterialFilterCetegory()
        {
            ClosePopUpIfVisible();
            Click(_materialFilter);

            return this;
        }

        public bool IsMaterialFilterCategoryChecked()
        {
            var materialFilterCheckbox = FindElement(_materialFilter);

            return materialFilterCheckbox.Selected;
        }

        public void GetAndShowAllVisibleProductTitle()
        {
            var listProduct = Instance.FindElements(By.ClassName("list-product-link"));

            for (int i = 0; i < listProduct.Count; i++)
            {
                Console.WriteLine(listProduct[i].GetAttribute("title"));
            }
        }
    }
}
