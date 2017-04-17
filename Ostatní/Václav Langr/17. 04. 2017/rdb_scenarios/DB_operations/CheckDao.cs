using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rdb_scenarios.DB_objects;

namespace rdb_scenarios.DB_operations
{
    class CheckDao
    {
        private SqlConnection myConnection;

        public CheckDao(SqlConnection myConnection)
        {
            this.myConnection = myConnection;
        }

        public void create(DB_objects.CheckPoint c)
        {
            SqlCommand comm = new SqlCommand("INSERT INTO check_point(name, description) VALUES(@name, @description)", myConnection);
            comm.Parameters.Add("@name", c.name);
            comm.Parameters.Add("@description", c.description);
        }

        public List<DB_objects.CheckPoint> retrieve()
        {
            List<DB_objects.CheckPoint> result = new List<DB_objects.CheckPoint>();
            SqlCommand comm = new SqlCommand("SELECT check_code, name, description " +
                                             "FROM check_point ", myConnection);
            SqlDataReader reader = comm.ExecuteReader();
            DB_objects.CheckPoint c;
            while (reader.Read())
            {
                c = new DB_objects.CheckPoint();
                c.check_code = Int32.Parse(reader[0].ToString());
                c.name = reader[1].ToString();
                c.description = reader[2].ToString();
                result.Add(c);
            }
            reader.Close();
            return result;
        }

        public SortedList<int, DB_objects.Operation> getOperations(int check_code)
        {
            SortedList<int, DB_objects.Operation> result = new SortedList<int, DB_objects.Operation>();
            SqlCommand comm = new SqlCommand("SELECT o.operation_code, o.name, o.description, t.[order] " +
                                             "FROM operation o, (SELECT operation_code, [order] " + 
                                                                "FROM check_operations " + 
                                                                "WHERE check_code=@check_code) t " +
                                             "WHERE o.operation_code=t.operation_code", myConnection);
            comm.Parameters.Add("@check_code", check_code);

            SqlDataReader reader = comm.ExecuteReader();
            DB_objects.Operation o;
            while (reader.Read())
            {
                o = new DB_objects.Operation();
                o.operation_code = Int32.Parse(reader[0].ToString());
                o.name = reader[1].ToString();
                o.description = reader[2].ToString();
                result.Add(Int32.Parse(reader[3].ToString()), o);
            }
            reader.Close();
            return result;
        }

        public List<DB_objects.Operation> getAvailable(int check_code)
        {
            List<DB_objects.Operation> result = new List<DB_objects.Operation>();
            SqlCommand comm = new SqlCommand("SELECT operation_code, name, description " + 
                                             "FROM operation " + 
                                             "WHERE operation_code NOT IN (SELECT operation_code " + 
                                                                          "FROM check_operations " + 
                                                                          "WHERE check_code=@check_code)", myConnection);
            comm.Parameters.Add("@check_code", check_code);

            SqlDataReader reader = comm.ExecuteReader();
            DB_objects.Operation o;
            while(reader.Read())
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

        public bool update(DB_objects.CheckPoint c)
        {
            SqlCommand comm = new SqlCommand("UPDATE check_point SET name=@name, description=@description WHERE check_code=@check_code", myConnection);
            comm.Parameters.Add("@name", c.name);
            comm.Parameters.Add("@description", c.description);
            comm.Parameters.Add("@check_code", c.check_code);
            return comm.ExecuteNonQuery() == 1;
        }

        public void delete(int check_code)
        {
            SqlCommand comm = new SqlCommand("DELETE FROM check_point WHERE check_code=@check_code", myConnection);
            comm.Parameters.Add("@check_code", check_code);
            comm.ExecuteNonQuery();
        }

        public void updateOperations(int check_code, SortedList<int, Operation> operations)
        {
            SqlCommand comm = new SqlCommand("DELETE FROM check_operations WHERE check_code=@check_code", myConnection);
            comm.Parameters.Add("@check_code", check_code);
            comm.ExecuteNonQuery();

            comm = new SqlCommand("INSERT INTO check_operations(operation_code, check_code, [order]) VALUES(@operation_code, @check_code, @order)", myConnection);
            for(int i = 0; i < operations.Keys.Count; i++)
            {
                comm.Parameters.Clear();
                comm.Parameters.Add("@operation_code", operations[operations.Keys[i]].operation_code);
                comm.Parameters.Add("@check_code", check_code);
                comm.Parameters.Add("@order", i + 1);
                comm.ExecuteNonQuery();
            }
        }
    }
}
