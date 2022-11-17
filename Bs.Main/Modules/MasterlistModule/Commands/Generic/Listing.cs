using Bs.Common;
using Bs.Main.Modules.MasterlistModule.Models;
using Bs.Main.Modules.MasterlistModule.ValueObjects;
using Bs.Main.Modules.MasterlistModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.Modules.MasterlistModule.Commands.Generic
{
    public class Listing : CommandBase
    {
        private IGenericModel Model;
        private readonly ViewModelBase Vm;
        public Listing(ViewModelBase vm, IGenericModel model) : base(vm)
        {
            Model = model;
            Vm = vm;
        }


        public override async void Execute(object parameter)
        {
            IEnumerable<object> items = new List<object>();
            
            await Task.Run(() => { items = Model.Get(); });

            Vm.NotifyCollectionChanged(items);
        }
    }
}
