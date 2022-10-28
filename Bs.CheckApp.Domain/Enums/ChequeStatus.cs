using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.CheckApp.Domain.Enums
{
    public enum ChequeStatus
    {
        OPEN = 0,
        CAREOF = 1,
        BLANK = 2,
        CLEARED = 3,
        REPLACED = 8,
        CANCELLED = 9
    }
}
