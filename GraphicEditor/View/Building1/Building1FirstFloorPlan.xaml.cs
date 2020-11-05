using System;
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

namespace GraphicEditor.View.Building1
{
    /// <summary>
    /// Interaction logic for Building1FirstFloorPlan.xaml
    /// </summary>
    public partial class Building1FirstFloorPlan : Page
    {
        private MainWindow mainWindow;
        public Building1FirstFloorPlan(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void buttonUp(object sender, RoutedEventArgs e)
        {
            mainWindow.MainFrame.Content = new Building1SecondFloorPlan(mainWindow);
            if(mainWindow.tabControl.SelectedIndex==0)
            {
                mainWindow.comboBoxH1.SelectedIndex = 2;
            }
            else
            {
                mainWindow.comboBoxHospital1.SelectedIndex = 2;
            }
        }

        private void buttonDown(object sender, RoutedEventArgs e)
        {
            mainWindow.MainFrame.Content = new Building1FloorPlan(mainWindow);
            if (mainWindow.tabControl.SelectedIndex == 0)
            {
                mainWindow.comboBoxH1.SelectedIndex = 0;
            }
            else
            {
                mainWindow.comboBoxHospital1.SelectedIndex = 0;
            }
        }
    }
}
