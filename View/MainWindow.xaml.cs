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
using WordleSearch.ViewModel;

namespace WordleSearch
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

        private void OnLetterButtonPressed(object sender, RoutedEventArgs e)
        {
            ((MainWindowModel)DataContext).OnLetterButtonPressed(sender, e);
        }

        private void OnResetButtonPressed(object sender, RoutedEventArgs e)
        {
            ((MainWindowModel)DataContext).OnResetButtonPressed(sender, e);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ((MainWindowModel)DataContext).TextBox_TextChanged(sender, e);
        }
    }
}
