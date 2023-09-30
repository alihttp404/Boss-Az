using Boss_Az.DB;
using Boss_Az.MenuConfigs;
using Boss_Az.Menus;
using Boss_Az.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boss_Az.Functions
{
    internal static class EmployeeFunctions
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

                Employee employee = new Employee(name!, surname!, email!, city!, phoneNumber!, age, password!);
                db.Employees!.Add(employee);
            }

            catch (Exception ex) { throw new Exception("Exception while employee signing up", ex); }
        }

        public static Employee SignIn(Database db) 
        {
            Console.WriteLine("Enter email: "); string email = Console.ReadLine();
            Console.WriteLine("Enter password: "); string password = Console.ReadLine();

            foreach (Employee? emp in db.Employees!)
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

        public static void ViewVacancies(Database db, Employee currEmployee)
        {
            while (true)
            {
                int ViewVacanciesPanelOpt = ProgramMenus.ViewVacanciesPanel.Start();

                switch (ViewVacanciesPanelOpt)
                {
                    case 0:
                        Menu UnfilteredVacancies = new Menu(new List<string>());
                        foreach (Vacancy? v in db.Vacancies!)
                        {
                            UnfilteredVacancies.Options.Add(v!.ToString());
                        }

                        while (true)
                        {
                            int UnfilteredVacanciesOpt = UnfilteredVacancies.Start("Press ESC to go back, press enter on the vacancy you wish to apply to\n\n");
                            if (UnfilteredVacanciesOpt == -1) break;
                            db.Vacancies[UnfilteredVacanciesOpt]?.Applications.Add(currEmployee);
                            db.Vacancies[UnfilteredVacanciesOpt]?.Author.Notifications.Add(new Notification($"Application to Vacancy {db.Vacancies[UnfilteredVacanciesOpt]?.ID}", currEmployee));
                        }
                        break;

                    case 1:
                        int jobCategoriesOpt = ProgramMenus.JobCategories.Start();
                        Menu FilteredVacancies = new Menu(new List<string>());
                        foreach (Vacancy? v in db.Vacancies!)
                        {
                            if (v.Category == ProgramMenus.JobCategories.Options[jobCategoriesOpt]) FilteredVacancies.Options.Add(v.ToString());
                        }
                        
                        while (true)
                        {
                            int FilteredVacanciesOpt = FilteredVacancies.Start("Press ESC to go back, press enter on the vacancy you wish to apply to\n\n");
                            if (FilteredVacanciesOpt == -1) break;
                            db.Vacancies[FilteredVacanciesOpt]?.Applications.Add(currEmployee);
                        }

                        break;

                    default:
                        break;
                }

                if (ViewVacanciesPanelOpt == -1) return;
            }
        }

        public static void AddCV(Database db, Employee currEmployee)
        {
            string category, schoolAttended, gitHubLink, linkedinLink, specialization;
            List<string> skills = new List<string>();
            List<CompanyEmployment> previousCompanies = new List<CompanyEmployment>();
            List<LanguageProficiency> knownLanguages = new List<LanguageProficiency>();
            bool hasDiplomaDistinction;
            float universityAdmissionScore;

           
            int jobCategoriesOpt = ProgramMenus.JobCategories.Start();
            category = ProgramMenus.JobCategories.Options[jobCategoriesOpt];

            Console.Write("Specialization: "); specialization = Console.ReadLine();

            Console.Write("School attended: "); schoolAttended = Console.ReadLine();

            Console.Write("Github link: "); gitHubLink = Console.ReadLine();
            Console.Write("LInkedin link: "); linkedinLink = Console.ReadLine();

            Console.WriteLine("Enter to add skill");
            string currSkill= "";

            while (true)
            {
                 ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

                 if (keyInfo.Key == ConsoleKey.Enter)
                 {
                     if (!string.IsNullOrWhiteSpace(currSkill))
                     {
                         skills.Add(currSkill);
                         Console.WriteLine($"\nSkill '{currSkill}' added.");
                         currSkill = "";
                     }
                 }
                 else if (keyInfo.Key == ConsoleKey.Escape)
                 {
                     Console.WriteLine("\nExiting the loop.");
                     break;
                 }
                 else
                 {
                     currSkill += keyInfo.KeyChar;
                     Console.Write(keyInfo.KeyChar);
                 }
             }

            Menu YesNo = new Menu(new List<string> { "Yes", "No" });
            int HasDiplomaDistinctionOpt;
            while (true)
            {
                HasDiplomaDistinctionOpt = YesNo.Start();
                if (HasDiplomaDistinctionOpt == 0) { hasDiplomaDistinction = true; break; }
                else { hasDiplomaDistinction = false; break; }
            }

            while (true)
            {
                string prevCompanyname;
                int prevCompanyStartYear, prevCompanyStartMonth, prevCompanyStartDay;
                int prevCompanyEndYear, prevCompanyEndMonth, prevCompanyEndDay;

                int EnterNewCompanyOpt = YesNo.Start("Enter new company?");
                if (EnterNewCompanyOpt == 0) 
                {
                    Console.Write("Enter company name: "); prevCompanyname = Console.ReadLine();
                    Console.Write("Enter company start Year: "); int.TryParse(Console.ReadLine(), out prevCompanyStartYear);
                    Console.Write("Enter company start Day: "); int.TryParse(Console.ReadLine(), out prevCompanyStartMonth);
                    Console.Write("Enter company start Month: "); int.TryParse(Console.ReadLine(), out prevCompanyStartDay);                    
                    
                    Console.Write("Enter company end Year: "); int.TryParse(Console.ReadLine(), out prevCompanyEndYear);
                    Console.Write("Enter company end Day: "); int.TryParse(Console.ReadLine(), out prevCompanyEndMonth);
                    Console.Write("Enter company end Month: "); int.TryParse(Console.ReadLine(), out prevCompanyEndDay);

                    previousCompanies.Add
                        (new CompanyEmployment
                        (
                            prevCompanyname, 
                            new DateTime(prevCompanyStartYear, prevCompanyStartMonth, prevCompanyStartDay),
                            new DateTime(prevCompanyEndYear, prevCompanyEndMonth, prevCompanyEndDay)
                        ));
                }

                else if (EnterNewCompanyOpt == 1) { break; }
            }

            while (true)
            {
                string language;
                string level;

                int EnterNewLanguageOpt = YesNo.Start("Enter new language?");

                if (EnterNewLanguageOpt == 0)
                {
                    Console.Write("Language: "); language = Console.ReadLine();
                    Console.Write("Level: "); level = Console.ReadLine();

                    knownLanguages.Add(new LanguageProficiency(language, level));
                }

                else break;
            }

            Console.WriteLine("University admission score: "); float.TryParse(Console.ReadLine(), out universityAdmissionScore);

            try
            {
                currEmployee.CV = new CV(specialization, schoolAttended, universityAdmissionScore,
                    skills, previousCompanies, knownLanguages, hasDiplomaDistinction, gitHubLink, linkedinLink, currEmployee, category);
            }

            catch (Exception ex) { throw new Exception(ex.Message, ex); }

            db.CVs.Add(currEmployee.CV);
         }
    }
}
