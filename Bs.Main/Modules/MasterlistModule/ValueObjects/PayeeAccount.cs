using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Bs.Main.Modules.MasterlistModule.ValueObjects
{
    public class PayeeAccount
    {
        public int Id { get; set; }
        public Guid PayeeId { get; set; }

        public Payee Payee { get; set; }

        public string AccountNumber { get; set; }

        public ObservableCollection<ParticularsKeyValue> DefaultParticulars { get; set; } = new();

        public DateTime DateCreated { get; set; }


        public PayeeAccount() { }

        public void Validate()
        {
            if (string.IsNullOrEmpty(AccountNumber))
                throw new Exception($"{nameof(AccountNumber)} should not be blank.");
        }


    }
}
