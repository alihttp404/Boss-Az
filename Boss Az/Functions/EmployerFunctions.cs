﻿using Boss_Az.DB;
using Boss_Az.MenuConfigs;
using Boss_Az.Menus;
using Boss_Az.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss_Az.Functions
{
    internal static class EmployerFunctions
    {
        public static void SignUp(Database db)
        {
            try
            {
                Console.Write("Enter your name: ");
                string? name = Console.ReadLine();

                Console.Write("Enter your surname: ");
                string? surname = Console.ReadLine();

                Console.Write("Enter your password: ");
                string? password = Console.ReadLine();

                Console.Write("Enter your email: ");
                string? email = Console.ReadLine();

                Console.Write("Enter your city: ");
                string? city = Console.ReadLine();

                Console.Write("Enter your phone number: ");
                string? phoneNumber = Console.ReadLine();

                Console.Write("Enter your age: ");
                int age = int.Parse(Console.ReadLine());

                Employer employer = new Employer(name!, surname!, email!, city!, phoneNumber!, age, password!);
                db.Employers!.Add(employer);
                CustomJson.Save(db.Employers, "employers");
            }

            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public static Employer SignIn(Database db)
        {
            db.Employers = CustomJson.Load<List<Employer>>("employers");

            Console.WriteLine("Enter email: "); string email = Console.ReadLine();
            Console.WriteLine("Enter password: "); string password = Console.ReadLine();

            foreach (Employer? emp in db.Employers!)
            {
                if (emp?.Email == email && emp?.Password == password)
                {
                    return emp!;
                }
            }

            try { throw new Exception("Invalid email or password"); }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
            finally { Utils.WaitForInput(); }
        }

        public static void AddVacancy(Database db, Employer currEmployer)
        {
            Console.Write("Enter job title: ");
            string jobTitle = Console.ReadLine();

            Console.Write("Enter company name: ");
            string companyName = Console.ReadLine();

            Console.Write("Enter job description: ");
            string jobDescription = Console.ReadLine();

            int StartYear, StartMonth, StartDay;
            int EndYear, EndMonth, EndDay;

            Console.Write("Enter company start Year: "); int.TryParse(Console.ReadLine(), out StartYear);
            Console.Write("Enter company start Day: "); int.TryParse(Console.ReadLine(), out StartMonth);
            Console.Write("Enter company start Month: "); int.TryParse(Console.ReadLine(), out StartDay);

            Console.Write("Enter company end Year: "); int.TryParse(Console.ReadLine(), out EndYear);
            Console.Write("Enter company end Day: "); int.TryParse(Console.ReadLine(), out EndMonth);
            Console.Write("Enter company end Month: "); int.TryParse(Console.ReadLine(), out EndDay);

            string category;
            int jobCategoriesOpt = ProgramMenus.JobCategories.Start();
            category = ProgramMenus.JobCategories.Options[jobCategoriesOpt];

            Vacancy newVacancy = new Vacancy(
                currEmployer,
                jobTitle,
                companyName,
                new DateTime(StartYear, StartMonth, StartDay),
                new DateTime(EndYear, EndMonth, EndDay),
                jobDescription,
                category);

            db.Vacancies.Add(newVacancy);
            currEmployer.Vacancies.Add(newVacancy);
            CustomJson.Save(db.Vacancies, "vacancies");
        }

        public static void SearchCandidates(Database db)
        {
            Console.Clear();

            Menu SelectViewMode = new Menu(new List<string>
            {
                "View all candidates",
                "Search by category",
                "Search by candidate name and surname",
                "Search by university score",
                "Search by number of known languages",
                "Search by experience",
                "Exit"
            });

            while (true)
            {
                int opt = SelectViewMode.Start();

                switch (opt)
                {
                    case 0:
                        foreach (Employee emp in db.Employees)
                            Console.WriteLine(emp);
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
