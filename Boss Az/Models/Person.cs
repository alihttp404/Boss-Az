using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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
                    throw new ArgumentException("Name must be at least 3 characters long.");
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
                    throw new ArgumentException("Surname must be at least 3 characters long.");
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
                    throw new ArgumentException("Invalid email address.");
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
                string phoneNumberPattern = @"^(?:0|994)(?:12|51|50|55|70|77)[^\w]{0,2}[2-9][0-9]{2}[^\w]{0,2}[0-9]{2}[^\w]{0,2}[0-9]{2}[^\d]$";
                if (!Regex.IsMatch(value, phoneNumberPattern))
                    throw new ArgumentException("Invalid phone number.");
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
                    throw new ArgumentException("Age must be at least 18.");
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
                this.name = name;
                this.surname = surname;
                this.email = email;
                this.city = city;
                this.phoneNumber = phoneNumber;
                this.age = age;
                Password = password;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while creating a Person object.\n\n", ex);
            }
        }
    }
}
