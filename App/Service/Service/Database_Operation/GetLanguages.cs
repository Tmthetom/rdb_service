using System.Collections.Generic;
using System.Data.SqlClient;

namespace Service.Database_Operation
{
    class GetLanguages
    {
        public static List<string> Get(Connection connection)
        {
            List<string> languages = new List<string>();
            SqlConnection myConnection = connection.GetConnection();
            SqlCommand command;
            using (command = new SqlCommand("SELECT Language_Code FROM Languages", myConnection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        languages.Add(reader.GetString(0));
                    }
                }
            }
            return languages;
        }
    }
}
