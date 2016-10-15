using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

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
    }
}
