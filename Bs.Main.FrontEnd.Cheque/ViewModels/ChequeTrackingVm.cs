using Bs.CheckApp.Domain.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bs.Main.FrontEnd.ChequeTracker.ViewModels
{
    public class ChequeTrackingVm : ObservableObject
    {
        public ObservableCollection<Cheque> Cheques { get; set; } = new();

    }
}
