using Boss_Az.DB;
using Boss_Az.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss_Az.Functions
{
    internal static class VacancyFunctions
    {
        public static void ShowAllVacancies(Database db)
        {
            foreach (Employer emp in db.Employers!)
            {
                foreach (Vacancy v in emp!.Vacancies)
                    Console.WriteLine(v);
            }
        }
    }
}
