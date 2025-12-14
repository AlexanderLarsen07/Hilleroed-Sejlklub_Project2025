using ConsoleMenu.Menu;
using ConsoleMenu.Methods.Members;
using Hillerød_Sejlklub_Library.Models.Events;
using Hillerød_Sejlklub_Library.Models.Members;
using Hillerød_Sejlklub_Library.Services;
Menu menu = new Menu();
Member Chairman = new Member("Chairman", 700, MembershipEnum.Medlem, "Chairman@Mail.yeet", "password", "17171717");//HUSK SLET
Chairman.Role = RoleEnum.Chairman;//
menu.SetChairman(Chairman);     //

Member Administrator = new Member("nicer", 7, MembershipEnum.PassiveMedlem, "nicer", "password", "17171717"); //HUSK SLET
Administrator.Role = RoleEnum.Administrator;//
menu.SetAdministrator(Administrator);       //

menu.ShowLoginPage();
