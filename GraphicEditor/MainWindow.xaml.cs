
﻿using GraphicEditor.View.Building1;
using GraphicEditor.View.Building2;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            String userType = "administrator";
            //String userType = "patient";
            //String userType = "secretary";
            //String userType = "doctor";
            InitializeComponent();
            Frame.Content = new MainPage(userType);
        }
    }
}
