using HostelControlService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelControlService.Interface
{
    internal interface IOrderRepository
    {
        void Add(OrderModel order);

        void Edit(OrderModel order);

        void Remove(string id);

        OrderModel GetById(string id);

        IEnumerable<OrderModel> GetByUsername(string username);

        IEnumerable<OrderModel> GetAll();

        IEnumerable<OrderModel> GetByRoomLevel(int roomLevel);

        IEnumerable<OrderModel> GetByCountMember(int countMember);
    }
}
