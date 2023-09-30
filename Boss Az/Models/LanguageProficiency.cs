using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss_Az.Models
{
    internal class LanguageProficiency
    {
        public LanguageProficiency(string language, string level)
        {
            Language = language;
            Level = level;
        }

        public string Language { get; set; }
        public string Level { get; set; }
    }
}
