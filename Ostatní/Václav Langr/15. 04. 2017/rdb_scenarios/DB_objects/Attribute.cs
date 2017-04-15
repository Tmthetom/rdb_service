using Newtonsoft.Json;


namespace rdb_scenarios.DB_objects
{
    class Attribute
    {
        [JsonIgnore]
        public int attribute_code { get; set; }

        public string type, value, language;
        public Attribute()
        {

        }

        public Attribute(string type, string value)
        {
            this.type = type;
            this.value = value;
        }

        public Attribute(string type, string value, string language)
        {
            this.type = type;
            this.value = value;
            this.language = language;
        }

        public string toJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
