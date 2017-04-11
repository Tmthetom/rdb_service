using Newtonsoft.Json;
using System.Collections.Generic;

namespace Service.Database_Export
{
    class Section
    {
        public string language_Code;
        public string name;

        public SortedList<int, CheckPoint> checkPoints;

        public Section(string language_Code, string name)
        {
            checkPoints = new SortedList<int, CheckPoint>();
            this.language_Code = language_Code;
            this.name = name;
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
