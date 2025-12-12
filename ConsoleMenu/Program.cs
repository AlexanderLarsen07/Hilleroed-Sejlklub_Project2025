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
Member m1 = new Member("name", 17, MembershipEnum.Medlem, "mail@yes.efs", "password", "12121212");
menu.SetChairman(m1);
Member m2 = new Member("gustaf", 19, MembershipEnum.Medlem, "gustaf@mail.com", "password", "13131313");
menu.SetChairman(m2);
Member m3 = new Member("steve", 64, MembershipEnum.PassiveMedlem, "steve@gmail.com", "password", "14141414");
menu.SetChairman(m3);

DateTime date1 = new DateTime(2004, 04, 12, 13, 30, 0);
DateTime date2 = new DateTime(2006, 04, 13, 11, 30, 0);
DateTime date3 = new DateTime(2020, 06, 24, 16, 45, 0);

BoatLot b1 = new BoatLot(400, 600);
BoatLot b2 = new BoatLot(500, 400);
BoatLot b3 = new BoatLot(300, 200);
menu.AddBoatLot(b1);
menu.AddBoatLot(b2);
menu.AddBoatLot(b3);

Event e1 = new Event(1, "title", date1, "description");
Event e2 = new Event(15, "Coffee", date2, "Free cookies");
Event e3 = new Event(9, "Boat prep", date3, "We prepare the War Canoes");
menu.AddEvent(e1);
menu.AddEvent(e2);
menu.AddEvent(e3);

Signup s1 = new Signup(e1, m1, "Comment-1");
Signup s2 = new Signup(e1, m1, "Comment-1");
Signup s3 = new Signup(e1, m1, "Coment-3");
menu.AddSignup(s1);
menu.AddSignup(s2);
menu.AddSignup(s3);

menu.ShowLoginPage();
//menu.MenuBlog(memer);
