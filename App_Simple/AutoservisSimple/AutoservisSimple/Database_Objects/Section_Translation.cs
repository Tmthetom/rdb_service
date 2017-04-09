using Newtonsoft.Json;

namespace AutoservisSimple.Database_Objects
{
    class Section_Translation
    {
        public int id_Section;
        public string language_Code;
        public string name;

        public Section_Translation(int id_Section, string language_Code, string name)
        {
            this.id_Section = id_Section;
            this.language_Code = language_Code;
            this.name = name;
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
        /// Convert object into JSON string
        /// </summary>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
