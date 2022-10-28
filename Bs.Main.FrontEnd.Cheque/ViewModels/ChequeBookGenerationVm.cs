using Bs.CheckApp.Domain.Models;
using Bs.Main.FrontEnd.ChequeTracker.Commands.Cheque_Books;
using Bs.Main.FrontEnd.ChequeTracker.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bs.Main.FrontEnd.ChequeTracker.ViewModels
{
    public class ChequeBookGenerationVm : ObservableObject
    {
        private ChequeBook chequeBook = new();
        public ChequeBook ChequeBook { get => chequeBook; set => SetProperty(ref chequeBook, value); }

        private IEnumerable<Cheque> cheques;
        public IEnumerable<Cheque> Cheques { get => cheques; set => SetProperty(ref cheques, value); }

        public ICommand Generate { get; }

        public ChequeBookGenerationVm(ChequeBooks model)
        {
            ChequeBook = new();
            
            cheques = new List<Cheque>();
            Cheques = new List<Cheque>();

            Generate = new Generate(this, model);

        }
    }
}
