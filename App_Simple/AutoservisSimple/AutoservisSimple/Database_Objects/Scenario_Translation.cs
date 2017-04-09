using Newtonsoft.Json;

namespace AutoservisSimple
{
    class Scenario_Translation
    {
        public int id_Scenario;
        public string language_Code;
        public string name;

        public Scenario_Translation(int id_Scenario, string language_Code, string name)
        {
            this.id_Scenario = id_Scenario;
            this.language_Code = language_Code;
            this.name = name;
        }

        public int GetID()
        {
            return id_Scenario;
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
