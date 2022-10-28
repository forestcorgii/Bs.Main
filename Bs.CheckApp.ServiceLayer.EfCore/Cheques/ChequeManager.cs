using Bs.CheckApp.Domain.Models;
using Bs.CheckApp.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.CheckApp.ServiceLayer.EfCore
{
    public class ChequeManager
    {

        private IDbContextFactory<ChequeDbContext> Factory { get; }

        public ChequeManager(IDbContextFactory<ChequeDbContext> factory)
        {
            Factory = factory;
        }


        public void Save(Cheque cheque)
        {
            using ChequeDbContext context = Factory.CreateDbContext();
            if (context.Cheques.Any(c => c.CheckNumber == cheque.CheckNumber))
                context.Update(cheque);
            else context.Add(cheque);

            context.SaveChanges();
        }


    }
}
