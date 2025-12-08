using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hillerød_Sejlklub_Library.Models.Members;

namespace ConsoleMenu.Controllers.Events
{
    public class EventMenuMethod
    {
        public void EventMenu(string theChoice ,string menuChoices, Member member)
        {
            while (theChoice != "q")
            {
                if (member.Role == null)
                {
                    switch (theChoice)
                    {
                        case "1":

                            break;
                    }
                }

                else if (member.Role == RoleEnum.Member)
                {

                }

                else if(member.Role == RoleEnum.Administrator || member.Role == RoleEnum.Chairman)
                {

                }
            }
        }
    }
}
