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

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for Building1FloorPlan.xaml
    /// </summary>
    public partial class Building1FloorPlan : Page
    {
        public Building1FloorPlan()
        {
            InitializeComponent();
        }
        public Building1FloorPlan(MainWindow mainWindow)
        {
            InitializeComponent();
            window = mainWindow;
        }
        MainWindow window;
    }
}