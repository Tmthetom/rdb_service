using Newtonsoft.Json;

namespace Service.Database_Objects
{
    class Operation_Translation
    {
        public int id_Operation;
        public string language_Code;
        public string name;

        public Operation_Translation(int id_Operation, string language_Code, string name)
        {
            this.id_Operation = id_Operation;
            this.language_Code = language_Code;
            this.name = name;
        }

        public int GetID()
        {
            return id_Operation;
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
