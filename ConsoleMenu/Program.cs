using ConsoleMenu.Menu;
using ConsoleMenu.Methods.Members;
using Hillerød_Sejlklub_Library.Models.Events;
using Hillerød_Sejlklub_Library.Models.Members;
using Hillerød_Sejlklub_Library.Services;
//Member memer = new Member("name", 2, MembershipEnum.Medlem, "mail", "password", "007");
Menu menu = new Menu();
Member Chairman = new Member("Chairman", 700, MembershipEnum.Medlem, "Chairman@Mail.yeet", "password", "17171717");//HUSK SLET
Chairman.Role = RoleEnum.Chairman;//
menu.SetChairman(Chairman);     //

menu.ShowLoginPage();
//menu.MenuBlog(memer);
