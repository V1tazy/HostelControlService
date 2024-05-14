using HostelControlService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelControlService.Interface
{
    internal interface IAccessRepository
    {
        void Add(AccessModel accessModel);

        void Edit(AccessModel accessModel);

        void Delete(int id);

        IEnumerable<AccessModel> GetAll();
    }
}
