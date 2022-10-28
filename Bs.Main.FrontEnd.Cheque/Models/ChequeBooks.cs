using Bs.CheckApp.Domain.Models;
using Bs.CheckApp.ServiceLayer.EfCore.Cheque_Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.FrontEnd.ChequeTracker.Models
{
    public class ChequeBooks
    {
        public ChequeBookGenerator Generator;
        public ChequeBookProvider Provider;
        public ChequeBookManager Manager;
        public ChequeBooks(ChequeBookGenerator generator, ChequeBookProvider provider, ChequeBookManager manager)
        {
            Generator = generator;
            Provider = provider;
            Manager = manager;
        }


        public IEnumerable<Cheque> GenerateCheques(ChequeBook chequeBook) =>
            Generator.GenerateCheques(chequeBook);


        public void Add(ChequeBook chequeBook) => Manager.Add(chequeBook);
    }
}
