using System;
using System.Text.RegularExpressions;


namespace WebAddressBookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {

        private string _allphones;
        private string _allmails;
        private string _fullname;
        private string _alluserinfo;

        public ContactData()
        {
        }

        public ContactData(string firstname) {
            Firstname = firstname;
        }
        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
        public string Firstname     { get; set; }
        public string Middlename    { get; set; }
        public string Lastname      { get; set; }
        public string Id            { get; set; }
        public string Address       { get; set; }
        public string Homephone     { get; set; }
        public string Mobile        { get; set; }
        public string WorkPhone     { get; set; }
        public string Email         { get; set; }
        public string Email2        { get; set; }
        public string Email3        { get; set; }

        public string AllUserInfo
        {
            get
            {
                if (_alluserinfo != null)
                {//1st Regex finds newlines,  2nd Regex finds "WMH:" and whitespaces
                    string a =  Regex.Replace(_alluserinfo, @"\r\n?|\n ", "");
                    return CleanUp(a);
                }
                return  CleanUp(Firstname) + CleanUp(Middlename) + CleanUp(Lastname)
                    +CleanUp(Address)
                    +CleanUp(Homephone)+CleanUp(Mobile)+CleanUp(WorkPhone)
                    +CleanUp(Email)+CleanUp(Email2)+CleanUp(Email3);
            }
            set => _alluserinfo = value;

        }

        public string Fullname
        {
            get
            {
                if (_fullname != null) { return _fullname; }
                return CleanUp(Firstname) + CleanUp(Middlename) + CleanUp(Lastname);
            }
            set => _fullname = value;
        }

        public string Allmails {
            get
            {
                if (_allmails != null)
                {
                    return Regex.Replace(_allmails, @"\r\n?|\n", ""); 
                    

                }
                 { return (CleanUp2( Email) +CleanUp2( Email2) + CleanUp2( Email3)).Trim(); }
            }
            set => _allmails = value;
        }
        public string Allphones {
            get
            {
                if (_allphones != null)
                {
                    return Regex.Replace(_allphones, @"\r\n?|\n", "");
                }
                    return (CleanUp(Homephone) + CleanUp(Mobile) + CleanUp(WorkPhone)).Trim(); 
            }
            set => _allphones = value;
        }

        public string CleanUp(string phone)
        {
            if (phone == null || phone == "") { return ""; }

            /* replace "[-()]" with "" in string with all phone numbers */
            return phone.Replace(" ", "").Replace("(", "").Replace(")", "").Replace("-", "")
                .Replace("H:", "").Replace("W:", "").Replace("M:", "");

        }
        public string CleanUp2(string mail) {
            return mail.Replace(" ", "");
        }

        public int CompareTo(ContactData other)
        {
            if(Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Firstname.CompareTo(other.Firstname);
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }
        public override int GetHashCode()
        {
            return Firstname.GetHashCode();
        }
        public override string ToString()
        {
            return "firstname: " + Firstname + ", lastname: " + Lastname + ", ID:" + Id + ", phones:" + _allphones;
        }
    }
}
