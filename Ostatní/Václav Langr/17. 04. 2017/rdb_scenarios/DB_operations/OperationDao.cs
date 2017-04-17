using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rdb_scenarios.DB_operations
{
    class OperationDao
    {
        private SqlConnection myConnection;

        public OperationDao(SqlConnection myConnection)
        {
            this.myConnection = myConnection;
        }

        public void create(DB_objects.Operation o)
        {
            SqlCommand comm = new SqlCommand("INSERT INTO operation(name, description) VALUES(@name, @description)", myConnection);
            comm.Parameters.Add("@name", o.name);
            comm.Parameters.Add("@description", o.description);
        }

        public List<DB_objects.Operation> retrieve()
        {
            List<DB_objects.Operation> result = new List<DB_objects.Operation>();
            SqlCommand comm = new SqlCommand("SELECT operation_code, name, description " +
                                             "FROM operation ", myConnection);
            SqlDataReader reader = comm.ExecuteReader();
            DB_objects.Operation o;
            while (reader.Read())
            {
                o = new DB_objects.Operation();
                o.operation_code = Int32.Parse(reader[0].ToString());
                o.name = reader[1].ToString();
                o.description = reader[2].ToString();
                result.Add(o);
            }
            reader.Close();
            return result;
        }

        public bool update(DB_objects.Operation o)
        {
            SqlCommand comm = new SqlCommand("UPDATE operation SET name=@name, description=@description WHERE operation_code=@operation_code", myConnection);
            comm.Parameters.Add("@name", o.name);
            comm.Parameters.Add("@description", o.description);
            comm.Parameters.Add("@operation_code", o.operation_code);
            return comm.ExecuteNonQuery() == 1;
        }

        public void delete(DB_objects.Operation o)
        {
            SqlCommand comm = new SqlCommand("DELETE FROM operation WHERE operation_code=@operation_code", myConnection);
            comm.Parameters.Add("@operation_code", o.operation_code);
            comm.ExecuteNonQuery();
        }
    }
}
