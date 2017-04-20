namespace Service.Database_Objects
{
    class Log
    {
        public int id_Log;
        public string timeDate;
        public string tableName;
        public string operation;
        public string userName;

        /// <summary>
        /// Create new log
        /// </summary>
        /// <param name="id_Log">Id of log</param>
        /// <param name="timeDate">Time of creating</param>
        /// <param name="tableName">Name of affected table</param>
        /// <param name="operation">Name of database operation</param>
        /// <param name="userName">Who did this operation</param>
        public Log(int id_Log, string timeDate, string tableName, string operation, string userName)
        {
            this.id_Log = id_Log;
            this.timeDate = timeDate;
            this.tableName = tableName;
            this.operation = operation;
            this.userName = userName;
        }
    }
}
