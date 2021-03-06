﻿using DAN_LVIII_Kristina_Garcia_Francisco.ViewModel;
using System.Windows;

namespace DAN_LVIII_Kristina_Garcia_Francisco
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Main window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel(this);
        }
    }
}
