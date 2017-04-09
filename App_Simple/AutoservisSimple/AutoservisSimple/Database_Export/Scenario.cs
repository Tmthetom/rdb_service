using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoservisSimple.Database_Export
{
    class Scenario
    {
        public string name;
        public string language;

        public SortedList<int, Database_Objects.Section_Translation> sections;
        public SortedList<int, CheckPoint> sections_CheckPoints;

        /// <summary>
        /// Create scenario
        /// </summary>
        /// <param name="name">Description</param>
        /// <param name="language">Language</param>
        public Scenario(string name, string language)
        {
            sections = new SortedList<int, Database_Objects.Section_Translation>();
            sections_CheckPoints = new SortedList<int, CheckPoint>();
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
            sections_CheckPoints.Add(section_OrderNumber, checkPoint);
        }

        /// <summary>
        /// Convert object into JSON string
        /// </summary>
        public string ToJson()
        {


            return "";
        }
    }
}
