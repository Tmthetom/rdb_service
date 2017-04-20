using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace rdb_scenarios.DB_operations
{
    class OperationAttributeDao
    {
        private SqlConnection myConnection;

        public OperationAttributeDao(SqlConnection myConnection)
        {
            this.myConnection = myConnection;
        }

        public bool create(DB_objects.Operation o, DB_objects.Attribute a)
        {
            SqlCommand comm = new SqlCommand("INSERT INTO operation_attributes(type, language, value) VALUES(@type, @language, @value)", myConnection);
            comm.Parameters.Add("@type", a.type);
            comm.Parameters.Add("@language", a.language);
            comm.Parameters.Add("@value", a.value);

            comm = new SqlCommand("SELECT attribute_code FROM operation_attributes WHERE type LIKE @type AND language LIKE @language AND value LIKE @value ORDER BY attribute_code DESC", myConnection);
            comm.Parameters.Add("@type", a.type);
            comm.Parameters.Add("@language", a.language);
            comm.Parameters.Add("@value", a.value);
            SqlDataReader reader = comm.ExecuteReader();
            int id = -1;
            reader.Read();
            id = Int32.Parse(reader[0].ToString());
            if (id == -1)
            {
                return false;
            }
            reader.Close();

            comm = new SqlCommand("INSERT INTO operation_contains(attribute_code, operation_code) VALUES(@attribute_code, @operation_code)", myConnection);
            comm.Parameters.Add("@attribute_code", id);
            comm.Parameters.Add("@operation_code", o.operation_code);
            return comm.ExecuteNonQuery() == 1;
        }

        public List<DB_objects.Attribute> retrieve(int operation_code)
        {
            List<DB_objects.Attribute> result = new List<DB_objects.Attribute>();
            SqlCommand comm = new SqlCommand("SELECT attribute_code, type, language, value " +
                                             "FROM operation_attributes " + 
                                             "WHERE attribute_code IN (SELECT attribute_code " + 
                                                                      "FROM operation_contains " + 
                                                                      "WHERE operation_code=@operation_code)", myConnection);
            comm.Parameters.Add("@operation_code", operation_code);
            SqlDataReader reader = comm.ExecuteReader();
            DB_objects.Attribute a;
            while(reader.Read())
            {
                a = new DB_objects.Attribute();
                a.attribute_code = Int32.Parse(reader[0].ToString());
                a.type = reader[1].ToString();
                a.language = reader[2].ToString();
                a.value = reader[3].ToString();
                result.Add(a);
            }
            reader.Close();
            return result;
        }

        public bool update(DB_objects.Attribute a)
        {
            SqlCommand comm = new SqlCommand("UPDATE operation_attributes SET type=@type, value=@value, language=@language WHERE attribute_code=@attribute_code", myConnection);
            comm.Parameters.Add("@type", a.type);
            comm.Parameters.Add("@value", a.value);
            comm.Parameters.Add("@language", a.language);
            comm.Parameters.Add("@attribute_code", a.attribute_code);
            return comm.ExecuteNonQuery() == 1;
        }

        public void delete(DB_objects.Attribute a)
        {
            SqlCommand comm = new SqlCommand("DELETE FROM operation_attributes WHERE attribute_code=@attribute_code", myConnection);
            comm.Parameters.Add("@attribute_code", a.attribute_code);
            comm.ExecuteNonQuery();
        }
    }
}
