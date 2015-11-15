using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProductService
{
    [DataContract]
    public class Employee
    {
        public Employee(string name, string email, string position, int age)
        {
            Name = name;
            Email = email;
            Position = position;
            Age = age;
        }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Position { get; set; }
        [DataMember]
        public int Age { get; set; }
    }
}
