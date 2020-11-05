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

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for Building2FloorPlan.xaml
    /// </summary>
    public partial class Building2FloorPlan : Page
    {
        public Building2FloorPlan()
        {
            InitializeComponent();
        }
        public Building2FloorPlan(MainWindow mainWindow)
        {
            InitializeComponent();
            window = mainWindow;
        }
        MainWindow window;
    }
}
