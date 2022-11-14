using System;
using System.Collections.Generic;

namespace Bs.Main.Modules.MasterlistModule.ValueObjects
{
    public class PayeeAccount
    {
        public int Id { get; set; }
        public Guid PayeeId { get; set; }

        public string AccountNumber { get; set; }

        public Dictionary<string, string> DefaultParticulars { get; set; }

        public DateTime DateCreated { get; set; } 

        public PayeeAccount(string accountNumber)
        {
            AccountNumber = accountNumber;
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(AccountNumber))
                throw new Exception($"{nameof(AccountNumber)} should not be blank.");
        }


    }
}
