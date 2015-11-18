using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public class Tag:IEquatable <Tag>
    {
        string name;
        int appearnce;
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        public int Appearence
        {
            set { this.appearnce = value; }
            get { return appearnce; }
        }

        public Tag()
        {
            name = "";
            appearnce = 0;
        }
        public Tag(string tagName, int number)
        {
            name = tagName;
            appearnce = number;
        }

        public bool Equals(Tag other)
        {
            if (other == null) return false;
            return (name.Equals(other.name));
        }
        public override int GetHashCode()
        {
            return name;
        }
    }
}
