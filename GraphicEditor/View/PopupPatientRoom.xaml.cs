using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for PopupPatientRoom.xaml
    /// </summary>
    public partial class PopupPatientRoom : UserControl
    {
        public PopupPatientRoom()
        {
            InitializeComponent();
        }

        public static bool IsOpen { get; internal set; }
        public static PlacementMode Placement { get; internal set; }
    }
}
