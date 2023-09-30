using Boss_Az.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss_Az.Models
{
    internal class Vacancy
    {
        public Employer Author { get; set; }

        public Guid ID {  get; set; } = Guid.NewGuid();

        private string jobTitle;
        public string JobTitle
        {
            get { return jobTitle; }
            set
            {
                if (value.Length < 1)
                    throw new ArgumentException("Job Title must have at least 1 character.");
                jobTitle = value;
            }
        }

        private string companyName;
        public string CompanyName
        {
            get { return companyName; }
            set
            {
                if (value.Length < 1)
                    throw new ArgumentException("Company Name must have at least 1 character.");
                companyName = value;
            }
        }

        private DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                if (value > EndDate)
                    throw new ArgumentException("Start Date cannot be later than End Date.");
                startDate = value;
            }
        }

        private DateTime endDate;
        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                if (value < StartDate)
                    throw new ArgumentException("End Date cannot be earlier than Start Date.");
                endDate = value;
            }
        }

        private string jobDescription;
        public string JobDescription
        {
            get { return jobDescription; }
            set { if (value.Length > 1) jobDescription = value; else throw new ArgumentException("Job description cannot be empty."); }
        }

        public List<Employee> Applications = new List<Employee>();

        public string Category { get; set; }

        public Vacancy()
        {
            
        }

        public Vacancy(Employer author, string jobTitle, string companyName, DateTime startDate, DateTime endDate, string jobDescription, string category)
        {
            Author = author;
            JobTitle = jobTitle;
            CompanyName = companyName;
            StartDate = startDate;
            EndDate = endDate;
            JobDescription = jobDescription;
            Category = category;
        }

        public override string ToString()
        {
            string authorInfo = $"Author: {Author.Name} {Author.Surname}";
            string jobIdInfo = $"Job ID: {ID}";
            string titleInfo = $"Job Title: {JobTitle}";
            string companyInfo = $"Company Name: {CompanyName}";
            string datesInfo = $"Dates: {StartDate:yyyy-MM-dd} to {EndDate:yyyy-MM-dd}";
            string descriptionInfo = $"Description: {JobDescription}";
            string category = $"Category: {Category}";

            return $"{authorInfo}\n{jobIdInfo}\n{titleInfo}\n{companyInfo}\n{datesInfo}\n{descriptionInfo}\n{category}";
        }
    }
}
