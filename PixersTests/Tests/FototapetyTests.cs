using NUnit.Framework;
using Pixers.Pages;
using Pixers.Pages.Fototapety;

namespace PixersTests.Tests
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

            Assert.IsTrue(FototapetyPage.IsProductDisplayed(), "Nie wyświetlono strony produktu.");
        }

        [Test]
        public static void ShouldOpenFototapetyBestsellerPage()
        {
            MainPage.GoTo(MainPageLinkType.FototapetyBestseller);

            Assert.IsTrue(FototapetyPage.IsBestsellerPage(), "Nie wyświetlono strony z najpopularniejszymi produktami w kategorii Fototapety.");
        }

        [Test]
        public static void ShouldAddProductToBasket()
        {
            ShouldSearchAndDisplayFototapeta();

            var fototapeta = new FototapetyPage();

            fototapeta.AddToBasket()
                .GoToBasket();

            Assert.Greater(fototapeta.ProductQuantityInBasket(), 0);
        }
    }
}
