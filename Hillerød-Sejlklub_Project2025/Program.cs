using Hillerød_Sejlklub_Library.Exceptions;
using Hillerød_Sejlklub_Library.Models.Boats;
using Hillerød_Sejlklub_Library.Models.Events;
using Hillerød_Sejlklub_Library.Models.Members;
using Hillerød_Sejlklub_Library.Services;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;
DateTime d1 = new(2025, 12, 3, 6, 0, 0);
Event eve1 = new(1, "title", d1, "description");
Console.WriteLine(eve1);
Console.WriteLine();

Member m1 = new("al", 12, MembershipEnum.FamilieMedlem, "mail", "pass", "122212");
Member m2 = new("la", 12, MembershipEnum.Medlem, "laim", "ssap", "212221");
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
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
try
{
    Console.WriteLine("---------------------------Test overdue true 6 hours, with motor, NoMemberAdded-----------------------------");
    DateTime start1 = new DateTime(2025, 12, 3, 6, 0, 0);
    DateTime end1 = new DateTime(2025, 12, 3, 12, 0, 0);
    Member member1 = new Member("Peter", 20, MembershipEnum.Medlem, "Peter@gmail", "password123", "12345678");
    MotorInfo motorInfo1 = new MotorInfo(FuelTypeEnum.Benzin, BrandEnum.Yamaha, 132, 50);
    Boat boat1 = new Boat("123456789", "name", "description", BoatTypeEnum.Voksenjolle, ModelEnum.Lynaes, 5, 123, 123, 123, 2010, motorInfo1);
    Booking booking1 = new Booking("Roskilde", start1, end1, member1, boat1);
    Console.WriteLine(booking1);
    Console.WriteLine("---------------------Test overdue false 3 hours, no motor, with AddMember------------------------");
    DateTime start2 = new DateTime(2025, 12, 3, 9, 0, 0);
    DateTime end2 = new DateTime(2025, 12, 3, 12, 0, 0);
    Member member2 = new Member("Thomas", 35, MembershipEnum.Medlem, "Thomas@gmail", "password12345", "22222222");
    Boat boat2 = new Boat("555555555", "TheBoat", "description", BoatTypeEnum.To_mandsjolle, ModelEnum.Optimistjolle, 2, 200, 50, 60, 2007, null);
    Booking booking2 = new Booking("Roskilde", start2, end2, member2, boat2);
    booking2.AddMember(member1); // add member 1 to booking2 
    Console.WriteLine(booking2);
    Console.WriteLine("----------------------------------GetAll + add booking1-----------------------------------");
    BookingRepo bookingRepo = new BookingRepo();
    List<Booking> bookingList = bookingRepo.GetAll();
    bookingRepo.AddBooking(booking1);
    bookingRepo.AddBooking(booking2);
    foreach (Booking bookingOnList in bookingList)
    {
        Console.WriteLine(bookingOnList);
    }
    Console.WriteLine("---------------------create booking3 with overlap------------------------");
    DateTime start3 = new DateTime(2025, 12, 3, 11, 0, 0);
    DateTime end3 = new DateTime(2025, 12, 3, 14, 0, 0);
    Booking booking3 = new Booking("Roskilde", start3, end3, member1, boat2);
    Console.WriteLine("----------------------------------------exception test and addbooking start----------------------------------------------------");
    //bookingRepo.AddBooking(booking3); // BookingID already exist
    Console.WriteLine("----------------------------------------exception test and addbooking end----------------------------------------------------");
    Console.WriteLine("----------------------------------------expection (already exist)----------------------------------------------------");
    //bookingRepo.AddBooking(booking2); //addbooking already booked.
    Console.WriteLine("----------------------------------------expection end----------------------------------------------------");
    Console.WriteLine("----------------------------------------getbookingbyid----------------------------------------------------");
    Booking getBooking2 = bookingRepo.GetBookingByID(2);
    //Booking getBooking5 = bookingRepo.GetBookingByID(5); //BookingID doesn't exist
    Console.WriteLine(getBooking2);
    Console.WriteLine("----------------------------------------printAllBookings----------------------------------------------------");
    bookingRepo.PrintAllBookings();
    Console.WriteLine("----------------------------------------remove booking 2 then printAllBookings----------------------------------------------------");
    bookingRepo.RemoveBookingByID(2);
    //bookingRepo.RemoveBookingByID(5); //BookingID doesn't exist
    bookingRepo.PrintAllBookings();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("---------------------------Booking Test End-----------------------------");
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("-----------------------------Test boat methods start:---------------------------------------------");
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("-----------------------------AddBoat---------------------------------------------");
    BoatRepo boatRepo = new BoatRepo();
    boatRepo.AddBoat(boat1);
    boatRepo.AddBoat(boat2);
    //boatRepo.AddBoat(boat2); //SailNumber already exist
    Console.WriteLine("---------------------------------------getAll-(name)-------------------------------------");
    List<Boat> getAllBoats = boatRepo.GetAll();
    foreach (Boat boatOnList in getAllBoats)
    Console.WriteLine(boatOnList.Name);
    Console.WriteLine("------------------------------------------Get by sailnumber test:----------------------------------------");
    Boat getByNumber = boatRepo.GetBoatBySailNumber("555555555");
    Console.WriteLine(getByNumber);
    Console.WriteLine("------------------------------------------------PrintAllBoats-----------------------------------------------");
    boatRepo.PrintAllBoats();
    Console.WriteLine("------------------------------------------------PrintBoatInfoToGuest-----------------------------------------------");
    boatRepo.PrintBoatInfoToGuest();
    Console.WriteLine("--------------------------------------------Remove then print all boatOnList---------------------------------------------------");
    boatRepo.RemoveBySailNumber("555555555");
    foreach (Boat boatOnList in getAllBoats)
    {
        Console.WriteLine(boatOnList);
    }
    //boatRepo.RemoveBySailNumber("584739021"); //SailNumber doesn't exist
    boatRepo.AddBoat(boat2);
    Console.WriteLine("-----------------------------Test boat methods end---------------------------------------------");
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("--------------------------------------------Repair methods test start---------------------------------------------");
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("-----------------------------------------GetAll test----------------------------------------------------");
    RepairRepo repairRepo = new RepairRepo();
    Repair repair1 = new Repair(1, "masten er ødelagt", boat1, false, true);
    Repair repair2 = new Repair(2, "et lille problem", boat1, false, false);
    List<Repair> repairList = repairRepo.GetAll();
    repairRepo.AddRepair(repair1);
    repairRepo.AddRepair(repair2);
    //repairRepo.AddRepair(repair2); //Number already exist
    foreach (Repair repairOnList in repairList)
    {
        Console.WriteLine(repairOnList);
    }
    Console.WriteLine("-----------------------------------------false true test boat 1 cannot sail----------------------------------------------------");
    Console.WriteLine($"Can boat1 sail: {boat1.CanSail}");
    Console.WriteLine($"Count List: {boat1.RepairLogList.Count}");
    Console.WriteLine("-----------------------------------------true true test with updateRepair boat 1 can sail----------------------------------------------------");
    boat1.UpdateRepair(repair1, 1, "masten var ødelagt, men nu er masten lavet", boat1, true, true);
    Console.WriteLine($"Can boat1 sail: {boat1.CanSail}");
    Console.WriteLine("---------------------------------------------printallrepair-----------------------------------------------------------------");
    repairRepo.PrintAllRepairs();
    Console.WriteLine("---------------------------------------------getrepair repair 1-----------------------------------------------------------------");
    Repair getRepair1 = repairRepo.GetRepair(1);
    //Repair getRepair = repairRepo.GetRepair(4); // number does not exist.
    Console.WriteLine(getRepair1);
    Console.WriteLine("----------------------------------------PrintAllTheRepairsToEachBoat----------------------------------------------");
    repairRepo.PrintAllTheRepairsToEachBoat(boatRepo);
    Console.WriteLine("----------------------------------------Remove repair 1----------------------------------------------");
    repairRepo.RemoveRepair(1);
    //repairRepo.RemoveRepair(5); //The number does not exist
    foreach (Repair repairOnList in repairList)
    {
        Console.WriteLine(repairOnList);
    }
}
catch (ExceptionSailNumber exs)
{
    Console.WriteLine("Exception sailnumber test:");
    Console.WriteLine(exs.Message);
}
catch (Exception ex)
{
    Console.WriteLine("Exception tests:");
    Console.WriteLine(ex.Message);   
}


//Member m1 = new Member("Justin", 22, true, "ddkwajld@gmail.com", "jidajip", 839139);
//Console.WriteLine(m1);



