﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraphicEditor.View
{
    /// <summary>
    /// Interaction logic for SearchAppointment.xaml
    /// </summary>
    public partial class SearchAppointment : Page
    {
        private MainPage page;
        public SearchAppointment( MainPage page)
        {
            InitializeComponent();
            this.page = page;
        }
    }
}
