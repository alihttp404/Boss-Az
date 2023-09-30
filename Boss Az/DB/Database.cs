using Boss_Az.Functions;
using Boss_Az.Menus;
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

        public void Start()
        {
            while (true)
            {
                int mainOpt = ProgramMenus.Main.Start();

                if (mainOpt == 0)
                {
                    while (true)
                    {
                        int employeeSignInSignUpOpt = ProgramMenus.SignInSignUp.Start();

                        if (employeeSignInSignUpOpt == 0)
                        {
                            try
                            {
                                CurrEmployee = EmployeeFunctions.SignIn(this);
                                EmployeeFunctions.Panel(this, CurrEmployee);
                            } catch (Exception ex ) { Console.WriteLine(ex.Message); Utils.WaitForInput(); }
                        }

                        else if (employeeSignInSignUpOpt == 1)
                        {
                            try
                            {
                                EmployeeFunctions.SignUp(this);
                            } catch (Exception ex) { Console.WriteLine(ex.Message); Utils.WaitForInput(); }
                        }

                        else break;
                    }
                }

                else if (mainOpt == 1)
                {
                    while (true)
                    {
                        int employerSignInSignUpOpt = ProgramMenus.SignInSignUp.Start();
                        if (employerSignInSignUpOpt == 0)
                        {
                            try
                            {
                                CurrEmployer = EmployerFunctions.SignIn(this);
                                //EmployerFunctions.Panel(this, CurrEmployee);
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); Utils.WaitForInput(); }
                        }

                        else if (employerSignInSignUpOpt == 1)
                        {
                            try
                            {
                                EmployerFunctions.SignUp(this);
                            } catch (Exception ex) { Console.WriteLine(ex.Message); Utils.WaitForInput(); }
                        }

                        else break;
                    }
                }

                else if (mainOpt == 2) break;
            }
        }
    }
}
