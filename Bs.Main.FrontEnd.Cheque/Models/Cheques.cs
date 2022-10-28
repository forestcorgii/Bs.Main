using Bs.CheckApp.Domain.Models;
using Bs.CheckApp.ServiceLayer.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.FrontEnd.ChequeTracker.Models
{
    public class Cheques
    {
        public ChequeManager ChequeManager;
        public ChequeProvider ChequeProvider;

        public Cheques(ChequeManager chequeManager, ChequeProvider chequeProvider)
        {
            ChequeManager = chequeManager;
            ChequeProvider = chequeProvider;
        }



        public IEnumerable<Cheque> GetCheques() =>
            ChequeProvider.GetCheques();


        public void Save(Cheque cheque) =>
            ChequeManager.Save(cheque);
    }
}
