using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private void ShowBuilding1Floor(object sender, MouseButtonEventArgs e)
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

        private void ShowBuilding2Floor(object sender, MouseButtonEventArgs e)
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
                ShowHospitalMap(null, null);
            }
            else if (H1.IsSelected)
            {
                ShowBuilding1Floor(null, null);
            }
            else if(H2.IsSelected)
            {
                ShowBuilding2Floor(null, null);
            }
        }
        private void comboBoxH1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dontRefreshMap = true;
            if (comboBoxH1.SelectedIndex == 0)
            {
                ShowBuilding1Floor(null, null);
            }
            else if (comboBoxH1.SelectedIndex == 1)
            {
                MessageBox.Show("Floor 1");
            }
            else if (comboBoxH1.SelectedIndex == 2)
            {
                MessageBox.Show("Floor 2");
            }
            else if (comboBoxH1.SelectedIndex == 3)
            {
                MessageBox.Show("Floor 3");
            }
        }

        private void comboBoxH2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dontRefreshMap = true;
            if (comboBoxH2.SelectedIndex == 0)
            {
                ShowBuilding2Floor(null, null);
            }
            else if (comboBoxH2.SelectedIndex == 1)
            {
                MessageBox.Show("Floor 1");
            }
            else if (comboBoxH2.SelectedIndex == 2)
            {
                MessageBox.Show("Floor 2");
            }
            else if (comboBoxH2.SelectedIndex == 3)
            {
                MessageBox.Show("Floor 3");
            }
        }
    }
}
