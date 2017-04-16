using Newtonsoft.Json;
using System.Collections.Generic;

namespace Service.Database_Objects
{
    class Section_Translation
    {
        public int id_Section;
        public string language_Code;
        public string name;

        public List<Database_Export.CheckPoint> checkPoints;

        public Section_Translation(int id_Section, string language_Code, string name)
        {
            this.checkPoints = new List<Database_Export.CheckPoint>();
            this.id_Section = id_Section;
            this.language_Code = language_Code;
            this.name = name;
        }

        public Section_Translation(Section_Translation parent)
        {
            this.checkPoints = new List<Database_Export.CheckPoint>();
            this.id_Section = parent.id_Section;
            this.language_Code = parent.language_Code;
            this.name = parent.name;
        }

        public int GetID()
        {
            return id_Section;
        }

        public string GetLanguage_Code()
        {
            return language_Code;
        }

        public string GetName()
        {
            return name;
        }

        /// <summary>
        /// Get number of components
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfCheckPoints()
        {
            return checkPoints.Count;
        }

        /// <summary>
        /// Convert object into JSON string
        /// </summary>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
