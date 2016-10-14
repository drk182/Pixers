using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Core;
using NUnit.Framework;
using Pixers.Pages;
using Pixers.Pages.Fototapety;

namespace PixersTests
{
    [TestFixture]
    public class FototapetyTests : Utilities.PixersTests
    {
        [Test]
        public static void ShouldSearchAndDisplayFototapeta()
        {
            MainPage.GoTo(MainPageLinkType.Fototapety);
            var fototapeta = new FototapetyPage();
            fototapeta.SearchFototapeta()
                .ClickOnFirstFindProduct();

            Assert.IsTrue(FototapetyPage.IsProductDisplayed(), "Nie wyświetlono produktu.");
        }
    }
}
