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

namespace MultiplePage
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

        private void rbt1_checked(object sender, RoutedEventArgs e)
        {
            CC.Content = new UserControl1();
        }

        private void rbt2_checked(object sender, RoutedEventArgs e)
        {
            CC.Content = new UserControl2();
        }

        private void rbt3_checked(object sender, RoutedEventArgs e)
        {
            CC.Content = new UserControl3();
        }
    }
}
