using HostelControlService.Interface;
using HostelControlService.Model;
using HostelControlService.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HostelControlService.Repositories
{
    internal class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(UserModel user)
        {
            using(var connection = GetConnection())
            using(var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Insert INTO users_table(Username, Password, Name, LastName, AccessId) " +
                    "Values(@Username, @Password, @Name, @LastName, @AccessId)";

                command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar).Value = user.Username;
                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar).Value = user.Password;
                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar).Value = user.Name;
                command.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar).Value = user.LastName;
                command.Parameters.Add("@AccessId", System.Data.SqlDbType.Int).Value = user.AccessLevel;


                command.ExecuteScalar();

                MessageBox.Show("Успешно");
            }
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using(var connection = GetConnection())
            using(var command = new SqlCommand())
            {
                connection.Open();

                command.Connection = connection;
                command.CommandText = "Select * From users_table where Username = @Username AND Password = @Password";


                command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar).Value = credential.UserName;
                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar).Value = credential.Password;


                validUser = command.ExecuteScalar() == null ? false : true;

                
            }

            return validUser;
        }

        public IEnumerable<UserModel> GetAll()
        {
            ObservableCollection<UserModel> users = new ObservableCollection<UserModel>();

            using(var connection = GetConnection())
            using(var command = new SqlCommand())
            {
                connection.Open();

                command.Connection = connection;
                command.CommandText = "Select * From user_table";

                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = new UserModel()
                        {
                            Id = reader[0].ToString(),
                            Username = reader[1].ToString(),
                            Password = string.Empty,
                            Name = reader[3].ToString(),
                            LastName = reader[4].ToString(),
                            AccessLevel = (int)reader[5]
                        };
                        users.Add(user);
                    }
                }

            }

            return users;
        }

        public IEnumerable<UserModel> GetByAccessLevel(int accessLevel)
        {
            ObservableCollection<UserModel> users = new ObservableCollection<UserModel>();

            using(var connection = GetConnection())
            using(var command = new SqlCommand())
            {
                connection.Open();

                command.Connection = connection;
                command.CommandText = "Select * From user_table where AccessId = @AccessId";

                command.Parameters.Add("@AccessId", System.Data.SqlDbType.Int).Value = accessLevel;

                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = new UserModel()
                        {
                            Id = reader[0].ToString(),
                            Username= reader[1].ToString(),
                            Password = string.Empty,
                            Name = reader[3].ToString(),
                            LastName = reader[4].ToString(),
                            AccessLevel = (int)reader[5]
                        };

                        users.Add(user);
                    }
                }
            }
            return users;
        }

        public UserModel GetById(string id)
        {
            UserModel user = null;

            using(var connection = GetConnection())
            using(var command = new SqlCommand())
            {
                connection.Open();

                command.Connection = connection;

                Guid GuidId;
                if(!Guid.TryParse(id, out GuidId))
                {
                    throw new ArgumentException("GuidId is not valid GUID");
                }

                command.CommandText = "Select * From users_table where Id = @Id";


                command.Parameters.Add("@Id", System.Data.SqlDbType.UniqueIdentifier).Value = GuidId;

                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user = new UserModel()
                        {
                            Id = reader[0].ToString(),
                            Username = reader[1].ToString(),
                            Password = string.Empty,
                            Name = reader[3].ToString(),
                            LastName = reader[4].ToString(),
                            AccessLevel = (int)reader[5]
                        };
                    }
                }
            }

            return user;
        }

        public UserModel GetByName(string username)
        {
            UserModel user = null;

            using(var connection = GetConnection())
            using(var command = new SqlCommand())
            {
                connection.Open();

                command.Connection = connection;

                command.CommandText = "Select * From users_table where Username =  @Username";
                command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar).Value = username;

                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user = new UserModel()
                        {
                            Id = reader[0].ToString(),
                            Username = reader[1].ToString(),
                            Password = string.Empty,
                            Name = reader[3].ToString(),
                            LastName = reader[4].ToString(),
                            AccessLevel = (int)reader[5]
                        };
                    }
                }
            }

            return user;
        }

        public void Remove(string id)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;

                Guid userGuid;
                if (!Guid.TryParse(id, out userGuid))
                {
                    throw new ArgumentException("UserId is not a valid GUID");
                }
                command.CommandText = "Delete From users_table Where Id = @Id";
                command.Parameters.Add("@Id", System.Data.SqlDbType.UniqueIdentifier).Value = userGuid;

                command.ExecuteScalar();
            }
        }

        public void Edit(UserModel user)
        {
            UserModel EditedUser = user;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @" UPDATE [User] SET Name = @Name, LastName = @LastName, AccessId = @AccessId
                WHERE Id = @Id AND Username = @Username";
                command.Parameters.AddWithValue("@Id", EditedUser.Id);
                command.Parameters.AddWithValue("@Username", EditedUser.Username);
                command.Parameters.AddWithValue("@Name", EditedUser.Name);
                command.Parameters.AddWithValue("@LastName", EditedUser.LastName);
                command.Parameters.AddWithValue("@AccessId", EditedUser.AccessLevel);


                command.ExecuteScalar();
            }
        }
    }
}
