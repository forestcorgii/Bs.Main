using Bs.Common;
using Bs.Common.Models;
using Bs.Common.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Common.Commands.Generic
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


        public override async void Execute(object? parameter)
        {
            try
            {
                IEnumerable<object> items = new List<object>();

                await Task.Run(() => { items = Model.Get(); });

                Vm.NotifyCollectionChanged(items);
            }
            catch (Exception ex) { MessageBoxes.Error(ex.Message); }
        }
    }
}
