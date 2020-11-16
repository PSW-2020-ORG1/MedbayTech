
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
        private Boolean dontRefreshMap;
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            MainFrame.Content = new HospitalMap(this);
            dontRefreshMap = false;

        }

        private void ShowHospitalMap(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new HospitalMap(this);
            Storyboard storyboard = new Storyboard();
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = 1;
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            storyboard.Children.Add(doubleAnimation);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(Canvas.OpacityProperty));
            Storyboard.SetTargetName(doubleAnimation, MainFrame.Name);
            storyboard.Begin(this);
        }

        private void ShowBuilding1GroundFloor(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Building1FloorPlan(this);
            Storyboard storyboard = new Storyboard();
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = 1;
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            storyboard.Children.Add(doubleAnimation);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(Canvas.OpacityProperty));
            Storyboard.SetTargetName(doubleAnimation, MainFrame.Name);
            storyboard.Begin(this);
        }
        private void ShowBuilding1FirstFloor(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Building1FirstFloorPlan(this);
            Storyboard storyboard = new Storyboard();
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = 1;
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            storyboard.Children.Add(doubleAnimation);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(Canvas.OpacityProperty));
            Storyboard.SetTargetName(doubleAnimation, MainFrame.Name);
            storyboard.Begin(this);
        }
        private void ShowBuilding1SecondFloor(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Building1SecondFloorPlan(this);
            Storyboard storyboard = new Storyboard();
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = 1;
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            storyboard.Children.Add(doubleAnimation);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(Canvas.OpacityProperty));
            Storyboard.SetTargetName(doubleAnimation, MainFrame.Name);
            storyboard.Begin(this);
        }
        private void ShowBuilding2GroundFloor(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Building2FloorPlan(this);
            Storyboard storyboard = new Storyboard();
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = 1;
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            storyboard.Children.Add(doubleAnimation);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(Canvas.OpacityProperty));
            Storyboard.SetTargetName(doubleAnimation, MainFrame.Name);
            storyboard.Begin(this);
        }

        private void ShowBuilding2FirstFloor(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Building2FirstFloorPlan(this);
            Storyboard storyboard = new Storyboard();
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = 1;
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            storyboard.Children.Add(doubleAnimation);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(Canvas.OpacityProperty));
            Storyboard.SetTargetName(doubleAnimation, MainFrame.Name);
            storyboard.Begin(this);
        }
        private void ShowBuilding2SecondFloor(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Building2SecondFloorPlan(this);
            Storyboard storyboard = new Storyboard();
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = 1;
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            storyboard.Children.Add(doubleAnimation);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(Canvas.OpacityProperty));
            Storyboard.SetTargetName(doubleAnimation, MainFrame.Name);
            storyboard.Begin(this);
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dontRefreshMap == true)
            {
                dontRefreshMap = false;
                return;
            }
            if(H1==null || H2==null || MAP==null)
            {
                return;
            }
            if (MAP.IsSelected)
            {
                comboBoxH1.SelectedItem = null;
                comboBoxH2.SelectedItem = null;
                ShowHospitalMap(null, null);
                DisableActiveUserControl(legenda);
            }
            else if (H1.IsSelected)
            {
                ShowBuilding1GroundFloor(null, null);
                comboBoxHospital1.SelectedIndex = 0;
                SetActiveUserControl(legenda);
            }
            else if(H2.IsSelected)
            {
                ShowBuilding2GroundFloor(null, null);
                comboBoxHospital2.SelectedIndex = 0;
                SetActiveUserControl(legenda);
            }
        }

        public void SetActiveUserControl(UserControl control)
        {
            legenda.Visibility = Visibility.Visible;
        }

        public void DisableActiveUserControl(UserControl control)
        {
           legenda.Visibility = Visibility.Collapsed;

        }
        private void comboBoxH1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dontRefreshMap == true) return;
            dontRefreshMap = true;
            comboBoxH2.SelectedItem = null;
            if (comboBoxH1.SelectedIndex == 0)
            {
                dontRefreshMap = true;
                ShowBuilding1GroundFloor(null, null);
                SetActiveUserControl(legenda);
            }
            else if (comboBoxH1.SelectedIndex == 1)
            {
                dontRefreshMap = true;
                ShowBuilding1FirstFloor(null, null);
                SetActiveUserControl(legenda);
            }
            else if (comboBoxH1.SelectedIndex == 2)
            {
                dontRefreshMap = true;
                ShowBuilding1SecondFloor(null, null);
                SetActiveUserControl(legenda);
            }
        }

        private void comboBoxHospital1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dontRefreshMap = true;
            if (comboBoxHospital1.SelectedIndex == 0)
            {
                ShowBuilding1GroundFloor(null, null);
                SetActiveUserControl(legenda);
            }
            else if (comboBoxHospital1.SelectedIndex == 1)
            {
                ShowBuilding1FirstFloor(null, null);
                SetActiveUserControl(legenda);
            }
            else if (comboBoxHospital1.SelectedIndex == 2)
            {
                ShowBuilding1SecondFloor(null, null);
                SetActiveUserControl(legenda);
            }
        }

        private void comboBoxH2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dontRefreshMap == true) return;
            dontRefreshMap = true;
            comboBoxH1.SelectedItem = null;
            if (comboBoxH2.SelectedIndex == 0)
            {
                dontRefreshMap = true;
                ShowBuilding2GroundFloor(null, null);
            }
            else if (comboBoxH2.SelectedIndex == 1)
            {
                dontRefreshMap = true;
                ShowBuilding2FirstFloor(null, null);
            }
            else if (comboBoxH2.SelectedIndex == 2)
            {
                dontRefreshMap = true;
                ShowBuilding2SecondFloor(null, null);
            }
        }
        private void comboBoxHospital2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dontRefreshMap = true;
            if (comboBoxHospital2.SelectedIndex == 0)
            {
                ShowBuilding2GroundFloor(null, null);
            }
            else if (comboBoxHospital2.SelectedIndex == 1)
            {
                ShowBuilding2FirstFloor(null, null);
            }
            else if (comboBoxHospital2.SelectedIndex == 2)
            {
                ShowBuilding2SecondFloor(null, null);
            }
        }
    }
}
