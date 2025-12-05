using Hillerød_Sejlklub_Library.Exceptions;
using Hillerød_Sejlklub_Library.Models.Boats;
using Hillerød_Sejlklub_Library.Models.Events;
using Hillerød_Sejlklub_Library.Models.Members;
using Hillerød_Sejlklub_Library.Services;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;
DateTime d1 = new(2025, 12, 3, 6, 0, 0);
Event eve1 = new(1, "title", d1, "description");
Console.WriteLine(eve1);
Console.WriteLine();

Member m1 = new("al", 12, MembershipEnum.FamilieMedlem, "mail", "pass", 122212);
Member m2 = new("la", 12, MembershipEnum.Medlem, "laim", "ssap", 212221);
Console.WriteLine(m1);
Console.WriteLine(m2);
Console.WriteLine();
try
{
    Signup s1 = new(eve1, m1, "comment");
    Signup s2 = new(eve1, m2, "tnemmoc");

    Console.WriteLine(s1);
    Console.WriteLine();
    Console.WriteLine(s2);
}
catch (EventFullException efe)
{
    Console.WriteLine(efe.Message);
}
catch(Exception exc)
{
    Console.WriteLine(exc.Message);
}
Console.WriteLine();

Console.WriteLine(eve1.ToString());



Console.WriteLine("---------------------------Booking Test Start-----------------------------");

Console.WriteLine("---------------------------Test overdue true 6 hours, with motor-----------------------------");
DateTime start1 = new DateTime(2025, 12, 3, 6, 0, 0);
DateTime end1 = new DateTime(2025, 12, 3, 12, 0, 0);
Member member1 = new Member("Peter", 20, MembershipEnum.Medlem, "Peter@gmail", "password123", 12345678);
MotorInfo motorInfo1 = new MotorInfo(FuelTypeEnum.Benzin, BrandEnum.Yamaha, 132, 50);
Boat boat1 = new Boat("123456789", "name", "description", BoatTypeEnum.Voksenjolle, ModelEnum.Lynaes, 5, 123, 123, 123, 2010, motorInfo1, true);
Booking booking1 = new Booking("Roskilde", 1, start1, end1, member1, boat1);
Console.WriteLine(booking1);
Console.WriteLine("---------------------Test overdue false 3 hours, no motor, AddMember------------------------");
DateTime start2 = new DateTime(2025, 12, 3, 9, 0, 0);
DateTime end2 = new DateTime(2025, 12, 3, 12, 0, 0);
Member member2 = new Member("Thomas", 40, MembershipEnum.Medlem, "Thomas@gmail", "password12345", 22222222);
Boat boat2 = new Boat("555555555", "TheBoat", "description", BoatTypeEnum.To_mandsjolle, ModelEnum.Optimistjolle, 2, 200, 50, 60, 2007, null, true);
Booking booking2 = new Booking("Roskilde", 2, start2, end2, member2, boat2);
booking2.AddMember(member1);
Console.WriteLine(booking2);

Console.WriteLine("---------------------------Booking Test End-----------------------------");

//Console.WriteLine(booking2);

//Member m1 = new Member("Justin", 22, true, "ddkwajld@gmail.com", "jidajip", 839139);
Console.WriteLine(m1);



