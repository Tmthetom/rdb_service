using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace rdb_scenarios.DB_objects
{
    class Section
    {
        public List<Attribute> attributes;
        public SortedList<int, CheckPoint> check_points;
        public string name, description;

        public Section()
        {
            attributes = new List<Attribute>();
        }

        public Section(string name, string description) : this()
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
