using ConsoleMenu.Menu;
using Hillerød_Sejlklub_Library.Models.Members;
using Hillerød_Sejlklub_Library.Services;

Menu menu = new Menu();
//menu.ShowLoginPage();
Member memer = new Member("name", 2, MembershipEnum.Medlem, "mail", "password", 007);
//menu.MenuBlog(memer);