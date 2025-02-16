using System;

namespace ZarzadzanieBudynkiem
{
    class Program
    {
        static void Main()
        {
            ZarzadzanieBazaDanych dbManager = new ZarzadzanieBazaDanych();
            Menu menu = new Menu(dbManager);
            menu.WyswietlMenu();
        }
    }
}