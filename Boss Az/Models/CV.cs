using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss_Az.Models
{
    internal class CV
    {
        private string specialization;
        public string Specialization
        {
            get { return specialization; }
            set
            {
                if (value.Length < 2)
                    throw new ArgumentException("Specialization minimum 2 characters.");
                specialization = value;
            }
        }

        private string schoolAttended;
        public string SchoolAttended
        {
            get { return schoolAttended; }
            set
            {
                if (value.Length < 2)
                    throw new ArgumentException("School attended minimum 2 characters.");
                schoolAttended = value;
            }
        }

        private float universityAdmissionScore;
        public float UniversityAdmissionScore
        {
            get { return universityAdmissionScore; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("University Admission Score cannot be negative.");
                universityAdmissionScore = value;
            }
        }

        public List<string> Skills = new List<string>();

        public List<CompanyEmployment> PreviousCompanies = new List<CompanyEmployment>();

        public List<LanguageProficiency> KnownLanguages = new List<LanguageProficiency>();

        private bool hasDiplomaDistinction;

        private string gitHubLink;
        public string GitHubLink
        {
            get { return gitHubLink; }
            set
            {
                if (!Uri.IsWellFormedUriString(value, UriKind.Absolute))
                    throw new ArgumentException("Invalid GitHub Link.");
                gitHubLink = value;
            }
        }

        private string linkedInLink;
        public string LinkedInLink
        {
            get { return linkedInLink; }
            set
            {
                if (!Uri.IsWellFormedUriString(value, UriKind.Absolute))
                    throw new ArgumentException("Invalid LinkedIn Link.");
                linkedInLink = value;
            }
        }

        public Employee Author { get; set; } = new Employee();

        public string Category { get; set; }

        public CV()
        {
            
        }

        public CV(string specialization, string schoolAttended, float universityAdmissionScore, 
                    List<string> skills, List<CompanyEmployment> previousCompanies, List<LanguageProficiency> knownLanguages, 
                    bool hasDiplomaDistinction, string gitHubLink, string linkedInLink, Employee author, string category)
        {
            try
            {
                Specialization = specialization;
                SchoolAttended = schoolAttended;
                UniversityAdmissionScore = universityAdmissionScore;
                Skills = skills;
                PreviousCompanies = previousCompanies;
                KnownLanguages = knownLanguages;
                this.hasDiplomaDistinction = hasDiplomaDistinction;
                GitHubLink = gitHubLink;
                LinkedInLink = linkedInLink;
                Author = author;
                Category = category;
            }

            catch (Exception ex) 
            {
                throw new Exception("Error while creating a CV object.\n\n", ex);
            }
        }
    }
}
