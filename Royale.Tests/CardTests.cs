using System.IO;
using System.Threading;
using Framework.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Royale.Pages;

namespace Royale.Tests
{
    public class CardTests
    {
        IWebDriver driver;
        [SetUp]
        public void BeforeEach()
        {
            Driver.Init();
            Pages.Pages.Init();
            Driver.GoTo("https://statsroyale.com/");
        }
        [TearDown]
        public void AfterEach()
        {
            Driver.Current.Quit();
        }

        static string[] cardName = {"Ice Spirit","Mirror"};
        [Test, Category("cards")]
        [TestCaseSource("cardName")]
        [Parallelizable(ParallelScope.Children)]
        public void Ice_Spirit_is_on_Cards_Page(string CardName)
        {
            Driver.Current.Manage().Window.FullScreen();
            // driver.FindElement(By.CssSelector("a[href='/cards']")).Click();
            // var cardsPage = new CardsPage(Driver.Current);
            Thread.Sleep(5000);
            var iceSpirit = Pages.Pages.Cards.GoTo().Get_CardByName(CardName);

            Assert.That(iceSpirit.Displayed);
 
        }
    }
}