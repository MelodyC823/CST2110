using System;
using System.Collections.Generic;
using System.Text;

namespace _2110.DataAccess
{
    public class Employee
    {
        public Employee()
        {
        }

        public Employee(string id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public string ID { get; set; }
        public string Name { get; set; }
    }
}
