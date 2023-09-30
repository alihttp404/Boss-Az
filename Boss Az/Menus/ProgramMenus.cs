using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boss_Az.MenuConfigs;

namespace Boss_Az.Menus
{
    internal static class ProgramMenus
    {
        public static Menu Main = new Menu(new List<string>
        {
            "Employee",
            "Employer",
            "Exit"
        });

        public static Menu SignInSignUp = new Menu(new List<string>
        {
            "Sign in",
            "Sign up",
            "Exit"
        });

        public static Menu EmployeePanel = new Menu(new List<string>
        {
            "View vacancies",
            "Add/Update CV",
            "Exit"
        });

        public static Menu EmployeeSignIn = new Menu(new List<string>
        {
            "Email: ",
            "Password: "
        });

        public static Menu ViewVacanciesPanel = new Menu(new List<string>
        {
            "View all vacancies",
            "View vacancies by category",
            "Go back"
        });

        public static Menu JobCategories = new Menu(new List<string>
        {
            "Accounting and Finance",
            "Administrative and Office Support",
            "Advertising and Marketing",
            "Agriculture and Farming",
            "Architecture and Engineering",
            "Arts and Entertainment",
            "Automotive",
            "Aviation and Aerospace",
            "Banking and Financial Services",
            "Construction and Trades",
            "Customer Service",
            "Education and Training",
            "Energy and Utilities",
            "Environmental Services",
            "Government and Public Administration",
            "Healthcare and Medical",
            "Hospitality and Tourism",
            "Human Resources",
            "Information Technology",
            "Insurance",
            "Legal",
            "Manufacturing and Production",
            "Media and Communications",
            "Nonprofit and Social Services",
            "Real Estate",
            "Retail",
            "Sales",
            "Science and Research",
            "Sports and Recreation",
            "Transportation and Logistics",
            "Writing and Editing"
        });


    }
}
