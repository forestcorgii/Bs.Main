using Bs.Main.FrontEnd.ChequeTracker.Models;
using Bs.Main.FrontEnd.ChequeTracker.ViewModels;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.FrontEnd.ChequeTracker.Commands.Cheque_Books
{
    public class Generate : IRelayCommand
    {
        private ChequeBookGenerationVm Vm;
        private ChequeBooks Model;
        public Generate(ChequeBookGenerationVm vm, ChequeBooks model)
        {
            Vm = vm;
            Model = model;
        }


        public event EventHandler? CanExecuteChanged;
        
        public bool executable = true;

        public bool CanExecute(object? parameter) => executable;

        public void Execute(object? parameter)
        {
            executable = false;

            Vm.Cheques = Model.GenerateCheques(Vm.ChequeBook);

            executable = true;
        }

        public void NotifyCanExecuteChanged() { }
    }
}
