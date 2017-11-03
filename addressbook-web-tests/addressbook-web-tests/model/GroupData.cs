

using System;

namespace WebAddressBookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        //  private string header = "";
        // private string footer = "";

        public GroupData(string name)
        {
            Name = name;
        }
        public GroupData(string name, string header, string footer, string id)
        {
            Name = name;
            Header = header;
            Footer = footer;
            Id = id;
        }
        public GroupData(string name, string header, string footer)
        {
            Name = name;
            Header = header;
            Footer = footer;
        }

        public string Name      { get; set; }
        public string Header    { get; set; }
        public string Footer    { get; set; }
        public string Id        { get; set; }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + Name+ " Id=" + Id;
        }

        public String GetCurTime()
        {
            DateTime thisDay = DateTime.Now;
            String hour = thisDay.Hour.ToString();
            String time = thisDay.Minute.ToString();
            String sec = thisDay.Second.ToString();
            String TheTime = "Hr_" + hour + ":" + time + "." + sec;
            return TheTime;            
        }

    }
}
