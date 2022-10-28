using Bs.Main.FrontEnd.ChequeTracker.Commands;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bs.Main.FrontEnd.ChequeTracker.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private string testText = string.Empty;
        public string TestText { get => testText; set => SetProperty(ref testText, value); }

        private List<string> autoCompleteTest = new();
        public List<string> AutoCompleteTest { get => autoCompleteTest; set => SetProperty(ref autoCompleteTest, value); }
        public object DraggedFiles { get; set; }



        public ICommand Import { get; }

        public MainViewModel()
        {
            Import = new ImportXls();

             
        }
    }
}
