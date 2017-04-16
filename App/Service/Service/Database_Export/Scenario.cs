using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Database_Export
{
    class Scenario
    {
        public string name;
        public string language;

        public SortedList<int, Database_Objects.Section_Translation> sections;

        /// <summary>
        /// Create scenario
        /// </summary>
        /// <param name="name">Description</param>
        /// <param name="language">Language</param>
        public Scenario(string name, string language)
        {
            sections = new SortedList<int, Database_Objects.Section_Translation>();
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
            if (!sections.ContainsKey(order_Number))
            {
                // There was problem, that sections objects where same and thery shared checkPoints
                // So we need to do copy of translation, with everything sare, but without checkPoints
                sections.Add(order_Number, new Database_Objects.Section_Translation(section));
            }
        }

        /// <summary>
        /// Add checkPoint into section
        /// </summary>
        /// <param name="section_OrderNumber">Section order number in scenario, where checkpoint is</param>
        /// <param name="checkPoint">CheckPoint object</param>
        public void AddCheckPoint(int section_OrderNumber, CheckPoint checkPoint)
        {
            foreach (KeyValuePair<int, Database_Objects.Section_Translation> section in sections)
            {
                if (section.Key == section_OrderNumber)
                {
                    section.Value.checkPoints.Add(checkPoint);
                    break;
                }
            }
        }

        /// <summary>
        /// Get number of components
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfSections()
        {
            return sections.Count;
        }

        /// <summary>
        /// Convert object into JSON string
        /// </summary>
        public string ToJson()
        {
            // Create Scenario
            string json = "{\"name\":\"" + name + "\",";
            json += "\"sections\":[";

            // Create Sections
            foreach (KeyValuePair<int, Database_Objects.Section_Translation> section in sections)
            {
                json += "{\"" + section.Key + "\":";
                json += JsonConvert.SerializeObject(section.Value) + "},";
            }

            // Final improvements
            json = json.Remove(json.LastIndexOf(','));
            json += "]";
            json += "}";
            return JValue.Parse(json).ToString(Formatting.Indented);
        }
    }
}
