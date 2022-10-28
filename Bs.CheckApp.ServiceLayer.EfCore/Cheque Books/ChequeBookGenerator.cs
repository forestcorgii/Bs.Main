using Bs.CheckApp.Domain.Models;
using Bs.CheckApp.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.CheckApp.ServiceLayer.EfCore.Cheque_Books
{
    public class ChequeBookGenerator
    {

        //private IDbContextFactory<ChequeDbContext> Factory { get; }

        //public ChequeBookGenerator(IDbContextFactory<ChequeDbContext> factory)
        //{
        //    Factory = factory;
        //}


        public IEnumerable<Cheque> GenerateCheques(ChequeBook chequeBook)
        {
            List<Cheque> openCheques = new();
            for (int index = 0; index < chequeBook.TotalCheque; index++)
                openCheques.Add(new Cheque()
                {
                    ChequeBookNumber = chequeBook.Id,
                    CheckNumber = (chequeBook.FirstChequeNumber + index)
                        .ToString(new string('0', chequeBook.LeadingZeros))
                });


            return openCheques;
        }
    }
}
