using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.CheckApp.Domain.Models
{
    public class ChequeBook
    {
        public int Id { get; set; }

        public string ChequeCode { get; set; }

        public int FirstChequeNumber { get; set; }
        public int TotalCheque { get; set; }

        public int LeadingZeros { get; set; }

        public bool Complete { get; set; }



    }
}
