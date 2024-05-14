using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HostelControlService.Model
{
    internal class RoomModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ImageSource Image {  get; set; }

        public int MemberCount { get; set; }

        public int RoomLevel { get; set; }
    }
}
