using Xunit;
using Bs.CheckApp.ServiceLayer.EfCore.Cheque_Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bs.CheckApp.Domain.Models;

namespace Bs.CheckApp.ServiceLayer.EfCore.Cheque_Books.Tests
{
    public class ChequeBookGeneratorTests
    {
        public ChequeBookGenerator Generator;
        public ChequeBookGeneratorTests()
        {
            Generator = new();
        }

        [Fact()]
        public void GenerateChequesTest()
        {
            ChequeBook expectedChequeBook = new()
            {
                Id = 1,
                ChequeCode = "CS16",
                FirstChequeNumber = 102012,
                LeadingZeros = 10,
                TotalCheque = 100
            };

            IEnumerable<Cheque> actualCheques = Generator.GenerateCheques(expectedChequeBook);

            Assert.NotNull(actualCheques);
            Assert.NotEmpty(actualCheques);
        }
    }
}