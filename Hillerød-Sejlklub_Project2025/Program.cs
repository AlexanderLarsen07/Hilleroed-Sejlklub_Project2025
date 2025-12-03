using Hillerød_Sejlklub_Library.Models;
DateTime d1 = new(2025, 12, 3, 6, 0, 0);
Event eve1 = new(1, "title", d1, "description");
Console.WriteLine(eve1);
Console.WriteLine();

Member m1 = new("al", true, "mail", "pass", 122212);
Member m2 = new("la", false, "laim", "ssap", 212221);
Console.WriteLine(m1);
Console.WriteLine(m2);
Console.WriteLine();

Signup s1 = new(eve1, m1, "comment");
Signup s2 = new(eve1, m2, "tnemmoc");
Console.WriteLine(s1);
Console.WriteLine();
Console.WriteLine(s2);

Console.WriteLine();

Console.WriteLine(eve1.ToString());