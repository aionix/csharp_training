using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {

        private string allphones;
        private string allmails;

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

        public string Allmails {
            get
            {
                if (allmails != null) { return allmails; }
                else { return (CleanUp2( Email) +CleanUp2( Email2) + CleanUp2( Email3)).Trim(); }
            }
            set
            {
                allmails = value;
            }
        }
        public string Allphones {
            get
            {
                if (allphones != null) { return allphones; }
                   else { return (CleanUp(Homephone) + CleanUp(Mobile) + CleanUp(WorkPhone)).Trim(); }
                //else { return CleanUp(allphones); }
            }
            set
            {
                allphones = value;
            }
        }

        public string CleanUp(string phone)
        {
            if (phone == null || phone == "") { return ""; }
            /* replace "[-()]" with "" in string with all phone numbers */            
            return phone.Replace(" ", "").Replace("(", "").Replace(")", "").Replace("-", "") + "\r\n";           
            //return Regex.Replace(phone, "[ -()]", "") +"\r\n";
        }
        public string CleanUp2(string mail) {
            return mail.Replace(" ", "") + "\r\n";
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
            return "firstname: " + Firstname + ", lastname: " + Lastname + ", ID:" + Id + ", phones:" + allphones;
        }
    }
}
