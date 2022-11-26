using Bs.Common;
using Bs.Common.Models;
using Bs.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Common.Commands.Generic
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
            try
            {
                if (MessageBoxes.Inquire("Sure?"))
                    Model.Delete(parameter);

                Vm.Reload();
            }
            catch (Exception ex) { MessageBoxes.Error(ex.Message); }
        }
    }
}
