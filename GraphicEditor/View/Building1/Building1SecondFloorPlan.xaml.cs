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
    /// Interaction logic for Building1SecondFloorPlan.xaml
    /// </summary>
    public partial class Building1SecondFloorPlan : Page
    {
        private MainWindow mainWindow;
        public Building1SecondFloorPlan(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void buttonDown(object sender, RoutedEventArgs e)
        {
            mainWindow.MainFrame.Content = new Building1FirstFloorPlan(mainWindow);
            if (mainWindow.tabControl.SelectedIndex == 0)
            {
                mainWindow.comboBoxH1.SelectedIndex = 1;
            }
            else
            {
                mainWindow.comboBoxHospital1.SelectedIndex = 1;
            }
        }
    }
}
