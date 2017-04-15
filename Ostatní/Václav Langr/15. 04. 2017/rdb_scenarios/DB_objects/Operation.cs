using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace rdb_scenarios.DB_objects
{
    class Operation
    {

        [JsonIgnore]
        public int operation_code { get; set; }

        public List<Attribute> attributes;
        public string name, description;

        public Operation()
        {
            attributes = new List<Attribute>();
        }

        public Operation(string name, string description) : this()
        {
            this.name = name;
            this.description = description;
        }

        public string toJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        internal void addAttribute(string type, string value, string language)
        {
            if (type.Equals("") || type == null)
            {
                return;
            }
            DB_objects.Attribute a = new Attribute(type, value, language);
            this.attributes.Add(a);
        }
    }
}
