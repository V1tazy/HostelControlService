using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelControlService.Model
{
    internal class OrderModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RoomId { get; set; }
        public bool Status { get; set; }
        public string UserId { get; set; }
    }
}
