﻿using System;
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

namespace TestWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public Sum Sum { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            /*
            Sum = new Sum();
            
            Sum.Num1 = "3";
            Sum.Num2 = "4";
            this.DataContext = Sum;
            */


        }



        /*
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("We dey here");
        }
        */
        private void Login(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Email: " + email.Text + "\nPassword: " + pass.Password);
        }
    }
}
