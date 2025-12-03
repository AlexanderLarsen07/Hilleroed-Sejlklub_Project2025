using Hillerød_Sejlklub_Library.Models;
using System.Runtime.CompilerServices;
DateTime d1 = new(2025, 12, 3, 6, 0, 0);
Event eve1 = new(1, "title", d1, "description");
Console.WriteLine(eve1);
Console.WriteLine();

//Member m1 = new("al", true, "mail", "pass", 122212);
//Member m2 = new("la", false, "laim", "ssap", 212221);
//Console.WriteLine(m1);
//Console.WriteLine(m2);
Console.WriteLine();

//Signup s1 = new(eve1, m1, "comment");
//Signup s2 = new(eve1, m2, "tnemmoc");
//Console.WriteLine(s1);
Console.WriteLine();
//Console.WriteLine(s2);

Console.WriteLine();

Console.WriteLine(eve1.ToString());



Console.WriteLine("---------------------------Booking Test-----------------------------");


Console.WriteLine("---------------------------Test overdue true 6 hours-----------------------------");
DateTime start1 = new DateTime(2025, 12, 3, 6, 0, 0);
DateTime end1 = new DateTime(2025, 12, 3, 12, 0, 0);
//Booking booking1 = new Booking("Roskilde", 1, start1, end1);
//Console.WriteLine(booking1);
Console.WriteLine("---------------------Test overdue false 3 hours------------------------");
DateTime start2 = new DateTime(2025, 12, 3, 9, 0, 0);
DateTime end2 = new DateTime(2025, 12, 3, 12, 0, 0);
//Booking booking2 = new Booking("Roskilde", 2, start2, end2);
//Console.WriteLine(booking2);


Console.WriteLine("---------------------------Member Test-----------------------------");
Member m1 = new Member("Joel", 22, true, "JoelsFanfictionMail@gmail.com","123141", 48481931);
Console.WriteLine(m1);


