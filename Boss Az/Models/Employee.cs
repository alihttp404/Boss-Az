using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss_Az.Models
{
    internal class Employee : Person
    {
        public CV CV = new CV();

        public Employee()
        {
            
        }

        public Employee(string name, string surname, string email, string city, string phoneNumber, int age, string password) 
            : base(name, surname, email, city, phoneNumber, age, password)
        {

        }
    }
}