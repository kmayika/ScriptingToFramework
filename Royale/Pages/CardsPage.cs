using Framework.Selenium;
using OpenQA.Selenium;

namespace Royale.Pages
{
    public class CardsPage : PageBase
    {
        public CardsPageMap Map;

        public CardsPage()
        {
            Map = new CardsPageMap();
        }

        public IWebElement Get_CardByName(string CardName)
        {
            if (CardName.Contains(" "))
            {
                CardName = CardName.Replace(" ", "+");
            }
            return Map.Card(CardName);
        }

        public CardsPage GoTo()
        {
            headerNav.GoToCardsPage();
            return this;
        }
    }

    public class CardsPageMap
    {
        public IWebElement Card(string name) => Driver.FindElement(By.CssSelector($"a[href*='{name}']"));
    }
}