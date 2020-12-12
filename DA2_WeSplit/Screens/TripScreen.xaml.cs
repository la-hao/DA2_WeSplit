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
using DA2_WeSplit.Database;
using DA2_WeSplit.Paging;

namespace DA2_WeSplit.Screens
{
    /// <summary>
    /// Interaction logic for TripScreen.xaml
    /// </summary>
    public partial class TripScreen : UserControl
    {
        public delegate void DelegateType(int type);
        public event DelegateType LearnMoreHandler;
        public event DelegateType AddNewTripHandler;

        TripViewModel tripVM;
        public int Type;
        public TripScreen(int type)
        {
            InitializeComponent();
            List<ChuyenDi> cdList;
            ChuyenDiDAOImpl cdDao = new ChuyenDiDAOImpl();
            switch (type)
            {
                case 0:
                    Type = 0;
                    cdList = cdDao.GetAllChuyenDi();
                    break;

                case 1:
                    Type = 1;
                    cdList = cdDao.GetCurrentTrip();
                    break;

                case 2:
                    Type = 2;
                    cdList = cdDao.GetPassedTrip();
                    break;

                default:
                    Type = 0;
                    cdList = cdDao.GetAllChuyenDi();
                    break;
            }
            this.tripVM = new TripViewModel(cdList);
            this.DataContext = tripVM;
            TripListView.ItemsSource = tripVM.TripList;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            keywordPlaceholderTextBlock.Visibility = Visibility.Hidden;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (keywordTextBox.Text.Length == 0)
            {
                keywordPlaceholderTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //NewTrip newTrip = new NewTrip();
            //newTrip.Show();
            if (AddNewTripHandler != null)
            {
                AddNewTripHandler(Type);
            }
        }

        private void LearnMoreButton_Click(object sender, RoutedEventArgs e)
        {
            if (LearnMoreHandler != null)
            {
                LearnMoreHandler(Type);
            }
        }


    }
}
