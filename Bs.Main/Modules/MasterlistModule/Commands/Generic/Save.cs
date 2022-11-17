using Bs.Common;
using Bs.Main.Modules.MasterlistModule.Models;
using Bs.Main.Modules.MasterlistModule.ValueObjects;
using Bs.Main.Modules.MasterlistModule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.Modules.MasterlistModule.Commands.Generic
{
    public class Save : CommandBase
    {
        private IGenericModel Model;
        private ViewModelBase Vm;
        public Save(ViewModelBase vm, IGenericModel model) : base(vm)
        {
            Model = model;
            Vm = vm;
        }


        public override void Execute(object parameter)
        {
            Model.Save(parameter);
            Vm.Reload();
        }
    }
}
