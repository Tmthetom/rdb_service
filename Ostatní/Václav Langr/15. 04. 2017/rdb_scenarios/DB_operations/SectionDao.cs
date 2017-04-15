using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rdb_scenarios.DB_operations
{
    class SectionDao
    {
        private SqlConnection myConnection;

        public SectionDao(SqlConnection myConnection)
        {
            this.myConnection = myConnection;
        }

        public void create(DB_objects.Section s)
        {
            SqlCommand comm = new SqlCommand("INSERT INTO section(name, description) VALUES(@name, @description)", myConnection);
            comm.Parameters.Add("@name", s.name);
            comm.Parameters.Add("@description", s.description);
        }

        public List<DB_objects.Section> retrieve()
        {
            List<DB_objects.Section> result = new List<DB_objects.Section>();
            SqlCommand comm = new SqlCommand("SELECT section_code, name, description " +
                                             "FROM section ", myConnection);
            SqlDataReader reader = comm.ExecuteReader();
            DB_objects.Section s;
            while (reader.Read())
            {
                s = new DB_objects.Section();
                s.section_code = Int32.Parse(reader[0].ToString());
                s.name = reader[1].ToString();
                s.description = reader[2].ToString();
                result.Add(s);
            }
            reader.Close();
            return result;
        }

        public bool update(DB_objects.Section s)
        {
            SqlCommand comm = new SqlCommand("UPDATE section SET name=@name, description=@description WHERE section_code=@section_code", myConnection);
            comm.Parameters.Add("@name", s.name);
            comm.Parameters.Add("@description", s.description);
            comm.Parameters.Add("@section_code", s.section_code);
            return comm.ExecuteNonQuery() == 1;
        }

        public void delete(int section_code)
        {
            SqlCommand comm = new SqlCommand("DELETE FROM section WHERE section_code=@section_code", myConnection);
            comm.Parameters.Add("@section_code", section_code);
            comm.ExecuteNonQuery();
        }
    }
}
