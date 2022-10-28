using Bs.CheckApp.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.CheckApp.ServiceLayer.EfCore.Cheque_Books
{
    public class ChequeBookProvider
    {

        private IDbContextFactory<ChequeDbContext> Factory { get; }

        public ChequeBookProvider(IDbContextFactory<ChequeDbContext> factory)
        {
            Factory = factory;
        }
    }
}
