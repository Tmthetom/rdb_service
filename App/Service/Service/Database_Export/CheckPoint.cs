using Newtonsoft.Json;
using System.Collections.Generic;

namespace Service.Database_Export
{
    class CheckPoint
    {
        public string name;
        public string language;

        public SortedList<int, Database_Objects.Operation_Translation> operations;

        /// <summary>
        /// Create checkpoint
        /// </summary>
        /// <param name="name">Description</param>
        /// <param name="language">Language</param>
        public CheckPoint(string name, string language)
        {
            operations = new SortedList<int, Database_Objects.Operation_Translation>();
            this.name = name;
            this.language = language;
        }

        /// <summary>
        /// Add operation into checkPoint
        /// </summary>
        /// <param name="order_Number">Operation order number in checkPoint</param>
        /// <param name="section">Operation object</param>
        public void AddOperation(int order_Number, Database_Objects.Operation_Translation operation)
        {
            operations.Add(order_Number, operation);
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
