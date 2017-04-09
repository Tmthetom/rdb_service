using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoservisSimple.Database_Objects
{
    class Language
    {
        string language_Code;
        string name;

        public Language(string language_Code, string name)
        {
            this.language_Code = language_Code;
            this.name = name;
        }
    }
}
