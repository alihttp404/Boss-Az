using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss_Az.Models
{
    internal class CompanyEmployment
    {
        public CompanyEmployment(string companyName, DateTime startDate, DateTime endDate)
        {
            CompanyName = companyName;
            StartDate = startDate;
            EndDate = endDate;
        }

        public string CompanyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
