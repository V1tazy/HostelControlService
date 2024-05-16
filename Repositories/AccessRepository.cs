using HostelControlService.Interface;
using HostelControlService.Model;
using HostelControlService.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HostelControlService.Repositories
{
    internal class AccessRepository : RepositoryBase, IAccessRepository
    {
        public void Add(AccessModel accessModel)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Insert INTO AccessLevel_table(Name) @Name";

                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar).Value = accessModel.Name;
                command.ExecuteScalar();

                MessageBox.Show("Успешно");
            }
        }

        public void Delete(int id)
        {
            using(var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Delete From AccessLevel_table where Id = @Id";

                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                command.ExecuteScalar();
            }
        }

        public void Edit(AccessModel accessModel)
        {
            using(var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Update AccessLevel_table SET Name = @Name where Id = @Id";

                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = accessModel.Id;
                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar).Value = accessModel.Name;

                command.ExecuteScalar();
            }
        }

        public IEnumerable<AccessModel> GetAll()
        {
            var rolesList = new List<AccessModel>();

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * From AccessLevel_table";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var role = new AccessModel()
                        {
                            Id = (int)reader[0],
                            Name = (string)reader[1]
                        };

                        rolesList.Add(role);
                    }
                }
            }
            return rolesList;
        }

    }
}
