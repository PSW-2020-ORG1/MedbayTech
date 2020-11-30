using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for AdditionalInformationPatientRoom.xaml
    /// </summary>
    public partial class AdditionalInformationPatientRoom : Window
    {
        public AdditionalInformationPatientRoom()
        {
            InitializeComponent();
            string path = Directory.GetCurrentDirectory();
            string new_path = path.Replace('\\', '/');
            string logo = new_path + "/View/WhiteLogo.png";
            imageLogo.Source = new BitmapImage(new Uri(@logo, UriKind.Absolute));
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
