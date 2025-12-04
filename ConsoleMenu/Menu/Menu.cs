using Hillerød_Sejlklub_Library.Models.Members;
using Hillerød_Sejlklub_Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace ConsoleMenu.Menu
{
    public class Menu
    {
        private static string mainMenuChoices = "\t1.Vis Members";

        private MemberRepo _memberRepository = new MemberRepo();

        private static string ReadChoice(string choices)
        {
            Console.Clear();
            Console.Write(choices);
            string choice = Console.ReadLine();
            Console.Clear();
            return choice.ToLower();
        }

        public void ShowMenu()
        {

        }
    }
}
