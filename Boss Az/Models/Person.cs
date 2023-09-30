using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Boss_Az.Functions;

namespace Boss_Az.Models
{
    internal abstract class Person
    {
        public List<Notification> Notifications { get; set; }

        public Guid ID { get; private set; }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length < 3)
                    throw new Exception("Name must be at least 3 characters long.");
                name = value;
            }
        }

        private string surname;
        public string Surname
        {
            get { return surname; }
            set
            {
                if (value.Length < 3)
                    throw new Exception("Surname must be at least 3 characters long.");
                surname = value;
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
                if (!Regex.IsMatch(value, emailPattern))
                    throw new Exception("Invalid email address.");
                email = value;
            }
        }

        public string Password { get; set; }

        private string city;
        public string City { get => city; set { if (value.Length > 1) city = value; } }

        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                string phoneNumberPattern = @"^(050|070|077|055|051)\d{7}$";
                if (!Regex.IsMatch(value, phoneNumberPattern))
                    throw new Exception("Invalid phone number.");
                phoneNumber = value;
            }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 18)
                    throw new Exception("Age must be at least 18.");
                age = value;
            }
        }

        public Person()
        {
            
        }

        protected Person(string name, string surname, string email, string city, string phoneNumber, int age, string password)
        {
            try
            {
                ID = Guid.NewGuid();
                Name = name;
                Surname = surname;
                Email = email;
                City = city;
                PhoneNumber = phoneNumber;
                Age = age;
                Password = password;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
