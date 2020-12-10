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

namespace DA2_WeSplit.Screens
{
    /// <summary>
    /// Interaction logic for AddNewTripScreen.xaml
    /// </summary>
    public partial class NewTripScreen : UserControl
    {
        public NewTripScreen()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            String tripName = txtTripName.Text;
            String location = txtLocation.Text;


            if (txtTripName.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên chuyến đi");
            }
            else if (txtLocation.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa điểm chuyến đi");
            }

            //chua xong
        }
    }
}