using ConsoleMenu.Menu;
using ConsoleMenu.Methods.Members;
using Hillerød_Sejlklub_Library.Models.Events;
using Hillerød_Sejlklub_Library.Models.Members;
using Hillerød_Sejlklub_Library.Services;
Menu menu = new Menu();

Member Administrator = new Member("nicer", 7, MembershipEnum.PassiveMedlem, "nicer", "password", "17171717"); //HUSK SLET
Administrator.Role = RoleEnum.Administrator;//
menu.SetAdministrator(Administrator);       //

menu.ShowLoginPage();
