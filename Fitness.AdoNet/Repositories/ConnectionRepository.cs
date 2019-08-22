using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Fitness.AdoNet.Repositories
{
    public interface IConnectionRepository
    {
        DataTable GetTableResult(string sql);
        void Execute(SqlCommand sql);
    }

    public class ConnectionRepository : IConnectionRepository
    {
        public DataTable GetTableResult(string sql)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseStr"].ConnectionString))
            {
                var comm = new SqlCommand(sql, connection);

                DataTable dt = new DataTable();

                var adapter = new SqlDataAdapter(comm);

                adapter.Fill(dt);

                return dt;
            }
        }

        public void Execute(SqlCommand comm)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseStr"].ConnectionString))
            {
                comm.Connection = connection;
                comm.Connection.Open();
                comm.ExecuteNonQuery();
            }
        }
    }
}
