using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.Menu
{
    public class Menu
    {
        // static strings for choices

        // lav repos

        private static string ReadChoice(string choices)
        {
            Console.Write("\x1b[2J"); // Clear screen
            Console.Write("\x1b[3J"); // Clear scrollback
            Console.Write("\x1b[H");  // Set cursor to home
            Console.Write(choices);
            string choice = Console.ReadLine();
            Console.Clear();
            return choice.ToLower();
        }

        // lav switch case
        //    public void ShowMemberMenu()
        //    {
        //        string theChoice = ReadChoice();
        //        while (theChoice != "q")
        //        {
        //            switch (theChoice)
        //        }
        //     }
    }
}
