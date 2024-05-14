using HostelControlService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelControlService.Interface
{
    internal interface IRoomRepository
    {

        void Add(RoomModel room);

        void Edit(RoomModel room);

        void Remove(string id);

        RoomModel GetById(string id);

        IEnumerable<RoomModel> GetAll();

        IEnumerable<RoomModel> GetByRoomLevel(int roomLevel);

        IEnumerable<RoomModel> GetByCountMember(int countMember);

        IEnumerable<RoomModel> GetFreeRoom(bool statusRoom);

        bool isRoomFree(string roomId);
    }
}
