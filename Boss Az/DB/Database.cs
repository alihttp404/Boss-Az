using Boss_Az.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss_Az.DB
{
    internal class Database
    {
        public Employer? CurrEmployer = new Employer();
        public Employee? CurrEmployee = new Employee();

        public List<Employer?>? Employers = new List<Employer?>();
        public List<Employee?>? Employees = new List<Employee?>();

        public List<Vacancy?>? Vacancies = new List<Vacancy?>();
        public List<CV?>? CVs = new List<CV?>();
    }
}
