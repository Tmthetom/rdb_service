using AutoservisSimple.Database_Objects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace AutoservisSimple.Database_Export
{
    class Scenario
    {
        public string name;
        public string language;

        public SortedList<int, Section_Translation> sections;

        /// <summary>
        /// Create scenario
        /// </summary>
        /// <param name="name">Description</param>
        /// <param name="language">Language</param>
        public Scenario(string name, string language)
        {
            sections = new SortedList<int, Section_Translation>();
            this.name = name;
            this.language = language;
        }

        /// <summary>
        /// Add section into scenario
        /// </summary>
        /// <param name="order_Number">Section order number in scenario</param>
        /// <param name="section">Section object</param>
        public void AddSection(int order_Number, Database_Objects.Section_Translation section)
        {
            sections.Add(order_Number, section);
        }

        /// <summary>
        /// Add checkPoint into section
        /// </summary>
        /// <param name="section_OrderNumber">Section order number in scenario</param>
        /// <param name="checkPoint_OrderNumber">CheckPoint order number in section</param>
        /// <param name="checkPoint">CheckPoint object</param>
        public void AddCheckPoint(int section_OrderNumber, CheckPoint checkPoint)
        {
            foreach (KeyValuePair<int, Section_Translation> section in sections)
            {
                if (sections.ContainsKey(section_OrderNumber))
                {
                    section.Value.checkPoints.Add(checkPoint);
                    break;
                }
            }
        }

        /// <summary>
        /// Convert object into JSON string
        /// </summary>
        public string ToJson()
        {
            // Create Scenario
            string json = "{\"name\":\"" + name + "\",";
            json += "\"sections\":[";
            bool arrayOpen = false;

            // Create Sections
            foreach (KeyValuePair<int, Section_Translation> section in sections)
            {
                arrayOpen = true;
                json += "{\"" + section.Key + "\":";
                json += JsonConvert.SerializeObject(section.Value) + "},";
            }

            // Final improvements
            json = json.Remove(json.LastIndexOf(','));
            if (arrayOpen)
            {
                json += "]";
            }
            json += "}";
            return JValue.Parse(json).ToString(Formatting.Indented);
        }
    }
}
