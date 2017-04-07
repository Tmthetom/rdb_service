using System.Collections.Generic;
using Newtonsoft.Json;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System;

namespace rdb_scenarios.DB_objects
{
    class Scenario
    {
        public List<Attribute> attributes;
        public string name, description;
        public SortedList<int, Section> sections;
        public SortedList<int, SortedList<int, CheckPoint>> section_checks;
        
        public Scenario()
        {
            attributes = new List<Attribute>();
            sections = new SortedList<int, Section>();
            section_checks = new SortedList<int, SortedList<int, CheckPoint>>();
        }

        public Scenario(string name, string description) : this()
        {
            this.name = name;
            this.description = description;
        }

        public void addCheck(int section_order, int check_order, CheckPoint cp)
        {
            if(!section_checks.ContainsKey(section_order))
            {
                section_checks.Add(section_order, new SortedList<int, CheckPoint>());
            }
            section_checks[section_order].Add(check_order, cp);
        }

        public void addSection(int order, Section sc)
        {
            if (!sections.ContainsKey(order)) {
                sections.Add(order, sc);
            }
        }

        public string toJson()
        {
            string json = "{\"attributes\":" + JsonConvert.SerializeObject(attributes) + ",";
            json += "\"name\":\"" + name + "\",\"description\":\"" + description + "\",";
            json += "\"sections\":[";
            bool arrayOpen = false;
            foreach (int key in sections.Keys)
            {
                arrayOpen = true;
                json += "{\"" + key + "\":";
                Section s = sections[key];
                if (section_checks.ContainsKey(key)) {
                    s.check_points = section_checks[key];
                }
                json += JsonConvert.SerializeObject(s) + "},";
            }
            json = json.Remove(json.LastIndexOf(','));
            if(arrayOpen)
            {
                json += "]";
            }
            json += "}";
            return JValue.Parse(json).ToString(Formatting.Indented);
        }

        internal void addAttribute(string type, string value, string language)
        {
            if(type.Equals("") || type == null)
            {
                return;
            }
            DB_objects.Attribute a = new Attribute(type, value, language);
            this.attributes.Add(a);
        }
    }
}
