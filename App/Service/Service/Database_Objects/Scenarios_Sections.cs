namespace Service.Database_Objects
{
    class Scenarios_Sections
    {
        private int id_Scenario;
        private int id_Section;
        private int id_CheckPoint;
        private int order_Number;

        /// <summary>
        /// Create connection
        /// </summary>
        /// <param name="id_Scenario">ID of parent</param>
        /// <param name="id_Section">ID child</param>
        /// <param name="id_CheckPoint">ID child of previous child</param>
        /// <param name="order_Number">Order number of child in parent</param>
        public Scenarios_Sections(int id_Scenario, int id_Section, int id_CheckPoint, int order_Number)
        {
            this.id_Scenario = id_Scenario;
            this.id_Section = id_Section;
            this.id_CheckPoint = id_CheckPoint;
            this.order_Number = order_Number;
        }

        /// <summary>
        /// Getter
        /// </summary>
        /// <returns>ID of parent</returns>
        public int GetId_Scenario()
        {
            return id_Scenario;
        }

        /// <summary>
        /// Getter
        /// </summary>
        /// <returns>ID of child</returns>
        public int GetId_Section()
        {
            return id_Section;
        }

        /// <summary>
        /// Getter
        /// </summary>
        /// <returns>ID child of previous child</returns>
        public int GetId_CheckPoint()
        {
            return id_CheckPoint;
        }

        /// <summary>
        /// Getter
        /// </summary>
        /// <returns>Order number of child in parent</returns>
        public int GetOrder_Number()
        {
            return order_Number;
        }

        /// <summary>
        /// Setter change order of child in parent
        /// </summary>
        /// <param name="order_Number">New order number of child in parent</param>
        public void SetOrder_Number(int order_Number)
        {
            if (order_Number > 0)
            {
                this.order_Number = order_Number;
            }
        }
    }
}
