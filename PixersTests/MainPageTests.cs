using NUnit.Framework;
using Pixers.Pages;

namespace PixersTests
{
    [TestFixture]
    public class MainPageTests : Utilities.PixersTests
    {
        [Test]
        public void ShouldOpenPixersMainPage()
        {
            Assert.IsTrue(MainPage.IsAt(), "Nie wyświetlono strony głównej Pixers");
        }
    }
}
