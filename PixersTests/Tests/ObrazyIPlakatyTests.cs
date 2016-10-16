using NUnit.Framework;
using Pixers.Pages;
using Pixers.Pages.ObrazyIPlakaty;

namespace PixersTests.Tests
{
    [TestFixture]
    public class ObrazyIPlakatyTests : Utilities.PixersTests
    {
        [Test]
        public static void ShouldOpenMaterialFilterCategory()
        {
            MainPage.GoTo(MainPageLinkType.ObrazyIPlakatyTematy);

            var obrazy = new ObrazyIPlakatyPage();
            obrazy.CheckMaterialFilterCetegory();

            Assert.IsTrue(obrazy.IsMaterialFilterCategoryChecked(), "Kategoria nie została zaznaczona.");
        }
    }
}
