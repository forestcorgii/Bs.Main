using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.CheckApp.Domain.ValueObjects
{
    public class ChequeCode
    {
        public string Code { get; set; }

        public Point PayeeLine1Point { get; set; }
        public Point PayeeLine2Point { get; set; }

        public Point DatePoint { get; set; }
        public string DateFormat { get; set; }

        public Point AmountPoint { get; set; }
        public Point AmountInWordPoint { get; set; }

    }
}
