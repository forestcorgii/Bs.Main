using Bs.CheckApp.Domain.Models;
using Bs.CheckApp.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bs.CheckApp.ServiceLayer.EfCore
{
    public class ChequeProvider
    {
        private IDbContextFactory<ChequeDbContext> Factory { get; }

        public ChequeProvider(IDbContextFactory<ChequeDbContext> factory)
        {
            Factory = factory;
        }


        public IEnumerable<Cheque> GetCheques()
        {
            using ChequeDbContext context = Factory.CreateDbContext();
            return context.Cheques.ToList();
        }
    }
}
