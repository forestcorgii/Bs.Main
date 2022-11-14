using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.Modules.MasterlistModule.ValueObjects
{
    public class Payee
    {
        public Guid Id { get; set; }
        public string PayeeName { get; set; }
        public string OwnerName { get; set; }

        public string Address { get; set; }
        public string Tin { get; set; }

        public string Remarks { get; set; }

        public DateTime DateCreated { get; set; } 
        public Payee(string payeeName)
        {
            Id = Guid.NewGuid();

            PayeeName = payeeName;
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(PayeeName))
                throw new Exception($"{nameof(PayeeName)} should not be blank.");
        }


    }
}
