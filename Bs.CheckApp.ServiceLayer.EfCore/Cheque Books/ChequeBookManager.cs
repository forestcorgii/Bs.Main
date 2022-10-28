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
    public class ChequeBookManager
    {

        private IDbContextFactory<ChequeDbContext> Factory { get; }

        public ChequeBookManager(IDbContextFactory<ChequeDbContext> factory)
        {
            Factory = factory;
        }



        public void FlagAsCompleted(ChequeBook cheque)
        {
            cheque.Complete = true;
            using ChequeDbContext context = Factory.CreateDbContext();
            context.Update(cheque);
            context.SaveChanges();
        }

        public void Add(ChequeBook cheque)
        {
            using ChequeDbContext context = Factory.CreateDbContext();
            context.Add(cheque);
            context.SaveChanges();
        }
    }
}
