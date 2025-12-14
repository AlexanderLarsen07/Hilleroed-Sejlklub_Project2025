using Hillerød_Sejlklub_Library.Interfaces;
using Hillerød_Sejlklub_Library.Models.Members;

namespace Hillerød_Sejlklub_Library.Services
{
    public class MemberRepo : IMemberRepo
    {
        private Dictionary<int, Member> _memberDictionary;
        public MemberRepo()
        {
            _memberDictionary = new Dictionary<int, Member>();
        }
        //adds Member
        public void AddMember(Member member)
        {
            if (!_memberDictionary.ContainsKey(member.MemberID))
            {
                //checks if email exists or not
                if (!EmailCheckExist(member.Mail!))
                {
                    _memberDictionary.Add(member.MemberID, member);
                }
                else
                {
                    Console.WriteLine("Email already in use!");
                }
            }
        }

        public bool EmailCheckExist(string email)
        {
            foreach (Member member in _memberDictionary.Values)
            {
                if (member.Mail == email)
                {
                    return true;
                }
            }
            return false;
        }
        public List<Member> GetAll()
        {
            return _memberDictionary.Values.ToList();
        }

        //removes a member by the entering id that matches member id
        public void RemoveMember(int id)
        {
            foreach(KeyValuePair<int, Member> member in _memberDictionary)
            {
                if(member.Key == id)
                {
                    _memberDictionary.Remove(member.Key);
                    return;
                }
            }
        }

        //adds a BoatLot to the member
        public void addBoatLotToMember(BoatLot b, Member member)
        {
            if(b.IsRented == false)
            {
                member._boatLotsRented.Add(b);
                b.IsRented = true;
            }
        }

        //return customer that contains the id
        public Member GetMemberById(int id)
        {
            if (_memberDictionary.ContainsKey(id))
            {
                return _memberDictionary[id];
            }
            return null!;
        }

        public Member GetAdministratorByRole()
        {
            RoleEnum role = RoleEnum.Administrator;
            foreach (KeyValuePair<int, Member> member in _memberDictionary)
            {
                if (member.Value.Role == RoleEnum.Administrator)
                {
                    member.Value.Role = role;
                    return member.Value;
                }
                else
                {
                    Console.WriteLine("No Admins Found");
                }
            }
            return null!;
        }

        public Member GetMemberByRole()
        {
            RoleEnum role = RoleEnum.Member;
            foreach (KeyValuePair<int, Member> member in _memberDictionary)
            {
                if (member.Value.Role == RoleEnum.Member)
                {
                    member.Value.Role = role;
                    return member.Value;
                }
                else
                {
                    Console.WriteLine("No Member Found");
                }
            }
            return null!;
        }

        public Member GetChairmanByRole()
        {
            RoleEnum role = RoleEnum.Chairman;
            foreach (KeyValuePair<int, Member> member in _memberDictionary)
            {
                if (member.Value.Role == RoleEnum.Chairman)
                {
                    member.Value.Role = role;
                    return member.Value;
                }
                else
                {
                    Console.WriteLine("No Chairman Found");
                }
            }
            return null!;
        }


        public void Print(Dictionary<int, Member> dictionary)
        {
            foreach (KeyValuePair<int, Member> member in dictionary)
            {
                Console.WriteLine(member);
            }
        }
        public void PrintAllMembers()
        {
            foreach (KeyValuePair<int, Member> members in _memberDictionary)
            {
                Console.WriteLine(members);
            }
        }

        //only administrator and chairmand can use this method
        public Member EditMembersMembership(int id, MembershipEnum membershipEnum) // - not done
        {
            return null!;
        }

        public Member? EditMember(int id, string name, int age, string mail, string password, string phoneNumber)
        {
            if (_memberDictionary.ContainsKey(id))
            {
                _memberDictionary[id].PhoneNumber = phoneNumber;
                _memberDictionary[id].Name = name;
                _memberDictionary[id].Age = age;
                //mail needs to be unique it can only be edited if the new mail
                //is NOT already in use
                if (_memberDictionary[id].Mail == null)
                {
                    _memberDictionary[id].Mail = mail;
                }
                else
                {
                    Console.WriteLine("Mail is already in use. Please try a different Mail.");
                }
                    _memberDictionary[id].Password = password;
                return _memberDictionary[id];
            }
            else
            {
                return null;
            }
        }

        //Added for funktionalitet i MenuLogin
        public Member ReturnMemberByMail(string mail)
        {
            foreach (KeyValuePair<int, Member> member in _memberDictionary)
            {
                if (member.Value.Mail == mail)
                {
                    member.Value.Mail = mail;
                }
                return member.Value;
            }
            return null!;
      
        }

        //public Member ReturnMemberByPassword(string password)
        //{
        //    foreach(KeyValuePair<int, Member> member in _memberDictionary)
        //    {
        //        if(member.Value.Password == password)
        //        {
        //            return member.Value;
        //        }
        //    }
        //    return null;
        //}
    }
}
