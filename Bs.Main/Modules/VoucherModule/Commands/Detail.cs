﻿using Bs.Common;
using Bs.Main.Modules.VoucherModule.ViewModels;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.Modules.VoucherModule.Commands
{
    public class Detail : CommandBase
    {

        public Detail(VoucherListingVm listingVm) : base(listingVm) { }

        public override void Execute(object parameter)
        {
            
        }

    }
}
