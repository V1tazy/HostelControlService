using HostelControlService.Interface;
using HostelControlService.Model;
using HostelControlService.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HostelControlService.Repositories
{
    internal class RoomRepository : RepositoryBase, IRoomRepository
    {
        public void Add(RoomModel room)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Insert INTO users(Username, Password, Name, LastName, AccessId) " +
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

        public void Edit(RoomModel room)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoomModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoomModel> GetByCountMember(int countMember)
        {
            throw new NotImplementedException();
        }

        public RoomModel GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoomModel> GetByRoomLevel(int roomLevel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoomModel> GetFreeRoom(bool statusRoom)
        {
            throw new NotImplementedException();
        }

        public bool isRoomFree(string roomId)
        {
            bool isFree = false;

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.CommandText = "Select Status From Room_table where Id = @Id";
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = roomId;

                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        isFree = (bool)reader[0];
                    }
                }
            }

            return isFree;
        }

        public void Remove(string id)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;

                command.CommandText = "Delete From users_table Where Id = @Id";
                command.Parameters.Add("@Id", System.Data.SqlDbType.UniqueIdentifier).Value = userGuid;

                command.ExecuteScalar();
            }
        }
    }
}
