using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace rdb_scenarios.DB_objects
{
    class CheckPoint
    {

        [JsonIgnore]
        public int check_code { get; set; }

        public List<Attribute> attributes;
        public SortedList<int, Operation> operations;
        public string name, description;
        public CheckPoint()
        {
            attributes = new List<Attribute>();
            operations = new SortedList<int, Operation>();
        }

        public CheckPoint(string name, string description) : this()
        {
            this.name = name;
            this.description = description;
        }

        public string toJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public void addOperation(int order, Operation o)
        {
            operations.Add(order, o);
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
