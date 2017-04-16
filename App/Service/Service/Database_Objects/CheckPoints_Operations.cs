namespace Service.Database_Objects
{
    class CheckPoints_Operations
    {
        private int id_CheckPoint;
        private int id_Operation;
        private int order_Number;

        /// <summary>
        /// Create connection
        /// </summary>
        /// <param name="id_CheckPoint">ID of parent</param>
        /// <param name="id_Operation">ID child</param>
        /// <param name="order_Number">Order number of child in parent</param>
        public CheckPoints_Operations(int id_CheckPoint, int id_Operation, int order_Number)
        {
            this.id_CheckPoint = id_CheckPoint;
            this.id_Operation = id_Operation;
            this.order_Number = order_Number;
        }

        /// <summary>
        /// Getter
        /// </summary>
        /// <returns>ID of parent</returns>
        public int GetId_CheckPoint()
        {
            return id_CheckPoint;
        }

        /// <summary>
        /// Getter
        /// </summary>
        /// <returns>ID of child</returns>
        public int GetId_Operation()
        {
            return id_Operation;
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
