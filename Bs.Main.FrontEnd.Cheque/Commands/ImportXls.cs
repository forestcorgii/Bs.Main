using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bs.Main.FrontEnd.ChequeTracker.Commands
{
    public class ImportXls : IRelayCommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool executable = true;

        public bool CanExecute(object? parameter) => executable;

        public void Execute(object? parameter)
        {
            if(parameter is string[] files)
                MessageBox.Show(files[0]);
        }

        public void NotifyCanExecuteChanged() { }
    }
}
