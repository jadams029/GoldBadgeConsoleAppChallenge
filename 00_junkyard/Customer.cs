using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_junkyard
{
    public class Customer
    {
        public int ID { get; set;  }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Items { get; set; } = new List<string>();
        public Customer (int id, string firstName, string lastName)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
