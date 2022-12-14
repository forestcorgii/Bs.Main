using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.Modules.MasterlistModule.ValueObjects
{
    public class JournalAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Rate { get; set; }

        public JournalAccount()
        {
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                throw new Exception($"{nameof(Name)} should not be blank.");

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
