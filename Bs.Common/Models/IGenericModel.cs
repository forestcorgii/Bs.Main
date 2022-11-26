using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Common.Models
{
    public interface IGenericModel
    {
        IEnumerable<object> Get();

        void Save(object item);
        void Delete(object item);
    }
}
