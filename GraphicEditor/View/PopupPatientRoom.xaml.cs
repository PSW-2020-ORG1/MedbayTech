using System.Windows.Controls;
using System.Windows.Controls.Primitives;


namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for PopupPatientRoom.xaml
    /// </summary>
    public partial class PopupPatientRoom : UserControl
    {
        public static bool IsOpen { get; internal set; }
        public static PlacementMode Placement { get; internal set; }

        public PopupPatientRoom()
        {
            InitializeComponent();
        }
    }
}
