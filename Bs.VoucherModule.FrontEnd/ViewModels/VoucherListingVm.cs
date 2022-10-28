﻿using Bs.VoucherModule.Domain.Entities;
using Bs.VoucherModule.FrontEnd.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bs.VoucherModule.FrontEnd.ViewModels
{
    public class VoucherListingVm : ObservableObject
    {
        public ObservableCollection<Voucher> Vouchers { get; set; } 

        public ICommand Listing { get; }

        public VoucherListingVm(Vouchers vouchers)
        {

        }
    }
}
