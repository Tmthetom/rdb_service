using Newtonsoft.Json;

namespace AutoservisSimple.Database_Objects
{
    class CheckPoint_Translation
    {
        public int id_CheckPoint;
        public string language_Code;
        public string name;

        public CheckPoint_Translation(int id_CheckPoint, string language_Code, string name)
        {
            this.id_CheckPoint = id_CheckPoint;
            this.language_Code = language_Code;
            this.name = name;
        }

        public int GetID()
        {
            return id_CheckPoint;
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
