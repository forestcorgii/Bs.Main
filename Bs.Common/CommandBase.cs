using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Common
{
    public class CommandBase : IRelayCommand
    {
        public ViewModelBase ViewModelBase;
        public CommandBase(ViewModelBase viewModelBase)
        {
            ViewModelBase = viewModelBase;
            ViewModelBase.CanExecuteChanged += ListingVm_CanExecuteChanged;
        }

        public virtual void Execute(object? parameter) { }


        public event EventHandler? CanExecuteChanged;
        public bool CanExecute(object? parameter) => ViewModelBase.Executable;
        private void ListingVm_CanExecuteChanged(object? sender, bool e) => NotifyCanExecuteChanged();
        public void NotifyCanExecuteChanged() =>
            CanExecuteChanged?.Invoke(this, new EventArgs());

    }
}
