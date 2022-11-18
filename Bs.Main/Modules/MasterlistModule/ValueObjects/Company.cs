using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.Modules.MasterlistModule.ValueObjects
{
    public class Company
    {
        public string Id { get; set; }
        public string Acronym { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Tin { get; set; }
        public string BranchCode { get; set; }

        public DateTime DateCreated { get; set; }

        public IEnumerable<CompanyAccount> CompanyAccounts { get; set; }


        public Company() { }
        public Company(string name, string acronym, string tin, string branchCode)
        {
            Name = name;
            Acronym = acronym;

            Tin = tin;
            BranchCode = branchCode;


            Id = GenerateId(this);
        }

        public static string GenerateId(Company company) => $"{company.Acronym}{company.BranchCode}";

        public void Validate()
        {
            if (string.IsNullOrEmpty(Acronym))
                throw new Exception($"{nameof(Acronym)} should not be blank.");
            if (string.IsNullOrEmpty(Name))
                throw new Exception($"{nameof(Name)} should not be blank.");
            if (string.IsNullOrEmpty(Tin))
                throw new Exception($"{nameof(Tin)} should not be blank.");
            if (string.IsNullOrEmpty(BranchCode))
                throw new Exception($"{nameof(BranchCode)} should not be blank.");
        }

        public override string ToString()
        {
            return Id;
        }
    }
}
