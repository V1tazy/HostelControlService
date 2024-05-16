using HostelControlService.Interface;
using HostelControlService.Model;
using HostelControlService.Utils;
using System;
using System.Collections.Generic;
using System.Data;
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

                command.CommandText = "Insert into Room_table(Name, Description, RoomLevel, Status, ImageSource) " +
                    "Values (@Name, @Description, @RoomLevel, @Status, @ImageSource)";

                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar).Value = room.Name;
                command.Parameters.Add("@Description", System.Data.SqlDbType.VarChar).Value = room.Description;
                command.Parameters.Add("@RoomLevel", System.Data.SqlDbType.Int).Value = room.RoomLevel;
                command.Parameters.Add("@Status", System.Data.SqlDbType.Bit).Value = room.RoomStatus;
                command.Parameters.Add("@ImageSource", System.Data.SqlDbType.VarChar).Value = "work";
                command.ExecuteScalar();

                MessageBox.Show("Успешно");
            }
        }

        public void Edit(RoomModel room)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;

                command.CommandText = "UPDATE Room_table SET Name = @Name, Description = @Description, RoomLevel = @RoomLevel, Status = @Status WHERE Id = @Id";

                command.Parameters.Add("@Name", SqlDbType.VarChar).Value = room.Name;
                command.Parameters.Add("@Description", SqlDbType.VarChar).Value = room.Description;
                command.Parameters.Add("@RoomLevel", SqlDbType.Int).Value = room.RoomLevel;
                command.Parameters.Add("@Status", SqlDbType.Bit).Value = room.RoomStatus;
                command.Parameters.Add("@Id", SqlDbType.Int).Value = room.Id;

                command.ExecuteNonQuery();

                MessageBox.Show("Успешно");
            }
        }

        public IEnumerable<RoomModel> GetAll()
        {
            var roomsList = new List<RoomModel>();

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Room_table";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var room = new RoomModel()
                        {
                            Id = (int)reader[0],
                            Name = (string)reader[1],
                            Description = (string)reader[2],
                            MemberCount = (int)reader[4],
                            RoomLevel = (int)reader[5],
                            RoomStatus = (bool)reader[6]
                        };

                        roomsList.Add(room);
                    }
                }
            }
            return roomsList;
        }

        public IEnumerable<RoomModel> GetByCountMember(int countMember)
        {
            throw new NotImplementedException();
        }

        public RoomModel GetById(string id)
        {
            throw new NotImplementedException();
        }

        public RoomModel GetByName(string username)
        {
            RoomModel room = null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * From Room_table Where Name = @Name";

                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar).Value = username;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        room = new RoomModel()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Description = reader.GetString(2),
                            MemberCount = reader.GetInt32(4),
                            RoomLevel = reader.GetInt32(5),
                            RoomStatus = reader.GetBoolean(6)
                        };
                    }
                }
            }
            return room;
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

                command.CommandText = "Delete From Room_table Where Id = @Id";
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                command.ExecuteScalar();
            }
        }
    }
}
