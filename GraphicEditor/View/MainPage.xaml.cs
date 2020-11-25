using System;
using GraphicEditor.View.Building1;
using GraphicEditor.View.Building2;
using System.Collections.Generic;
using System.Text;
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
using System.IO;

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private Boolean dontRefreshMap;
        private static int Restriction;

        public MainPage(String user)
        {
            InitializeComponent();
            MainFrame.Content = new HospitalMap(this);
            setRestrictionType(user);
            string path = Directory.GetCurrentDirectory();
            string new_path = path.Replace('\\', '/');
            string logo = new_path + "/View/WhiteLogo.png";
            imageLogo.Source = new BitmapImage(new Uri(@logo, UriKind.Absolute));
        }

        private void setRestrictionType(String user)
        {
            if (user.Equals("administrator")) Restriction = 0;
            else if (user.Equals("patient")) Restriction = 1;
            else if (user.Equals("secretary")) Restriction = 2;
            else if (user.Equals("doctor")) Restriction = 3;
        }

        public int getRestriction()
        {
            return Restriction;
        }

        private void TransitionAnimation()
        {
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

        private void ShowHospitalMap(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new HospitalMap(this);
            TransitionAnimation();
        }
        private void ShowBuilding1GroundFloor(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Building1FloorPlan(this);
            TransitionAnimation();
            
        }
        private void ShowBuilding1FirstFloor(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Building1FirstFloorPlan(this);
            TransitionAnimation();
        }
        private void ShowBuilding1SecondFloor(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Building1SecondFloorPlan(this);
            TransitionAnimation();
        }
        private void ShowBuilding2GroundFloor(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Building2FloorPlan(this);
            TransitionAnimation();
        }

        private void ShowBuilding2FirstFloor(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Building2FirstFloorPlan(this);
            TransitionAnimation();
        }
        private void ShowBuilding2SecondFloor(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new Building2SecondFloorPlan(this);
            TransitionAnimation();
        }

        private void EnterKey(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if (Rooms.IsChecked == true)
                {
                    MainFrame.Content = new SearchResultsForRooms(this);
                }
                else if ((bool)Medicines.IsChecked)
                {
                    if (Restriction == 0)
                    {
                        MainFrame.Content = new SearchResultsForMedicines(this);
                    }
                }
                else if ((bool)Equipment.IsChecked)
                {
                    if (Restriction == 0)
                    {
                        MainFrame.Content = new SearchResaultsForEquipment(this);
                    }
                }
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dontRefreshMap == true)
            {
                dontRefreshMap = false;
                return;
            }
            if (H1 == null || H2 == null || MAP == null)
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
            else if (H2.IsSelected)
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
                SetActiveUserControl(legenda);
            }
            else if (comboBoxH2.SelectedIndex == 1)
            {
                dontRefreshMap = true;
                ShowBuilding2FirstFloor(null, null);
                SetActiveUserControl(legenda);
            }
            else if (comboBoxH2.SelectedIndex == 2)
            {
                dontRefreshMap = true;
                ShowBuilding2SecondFloor(null, null);
                SetActiveUserControl(legenda);
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
