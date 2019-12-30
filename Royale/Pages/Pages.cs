using System;

namespace Royale.Pages
{
    public class Pages
    {
        [ThreadStatic]
        public static CardsPage Cards;

        public static void Init()
        {
            Cards = new CardsPage();
        }
    }
}