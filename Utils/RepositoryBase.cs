using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelControlService.Utils
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;


        public RepositoryBase()
        {
            _connectionString = "Data Source=localhost;Initial Catalog=HotelControlServiceDB;Integrated Security=True;Trust Server Certificate=True";
        }


        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
