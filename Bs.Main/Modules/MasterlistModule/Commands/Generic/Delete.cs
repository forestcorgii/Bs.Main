using Bs.Common;
using Bs.Common.Utils;
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
    public class Delete : CommandBase
    {
        private IGenericModel Model;
        private ViewModelBase Vm;
        public Delete(ViewModelBase vm, IGenericModel model) : base(vm)
        {
            Model = model;
            Vm = vm;
        }


        public override void Execute(object parameter)
        {
            if (MessageBoxes.Inquire("Sure?"))
                Model.Delete(parameter);
            
            Vm.Reload();
        }
    }
}
