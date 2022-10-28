using Bs.Main.FrontEnd.ChequeTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bs.Main.FrontEnd.ChequeTracker.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void DataGrid_Drop(object sender, DragEventArgs e)
        {
            if (DataContext is MainViewModel mainViewModel)
                mainViewModel.Import.Execute(e.Data.GetData(DataFormats.FileDrop));
        }
         
    }
}
