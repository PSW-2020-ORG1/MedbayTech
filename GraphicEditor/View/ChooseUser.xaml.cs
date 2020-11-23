using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for ChooseUser.xaml
    /// </summary>
    public partial class ChooseUser : Page
    {
        public static int Restriction { get; set; }

        public ChooseUser()
        {
            InitializeComponent();
            Restriction = 0;
        }
        public ChooseUser(MainWindow mainWindow)
        {
            InitializeComponent();
            Restriction = 0;
            window = mainWindow;
        }
        MainWindow window;

        private void AdministratorBtn_Click(object sender, RoutedEventArgs e)
        {
            window.Frame.Content = new Login(window);
        }

        private void DoctorBtn_Click(object sender, RoutedEventArgs e)
        {
            window.Frame.Content = new Login(window);
        }

        private void SecretaryBtn_Click(object sender, RoutedEventArgs e)
        {
            window.Frame.Content = new Login(window);
        }

        private void PatientBtn_Click(object sender, RoutedEventArgs e)
        {
            Restriction = 1;
            window.Frame.Content = new Login(window);
        }

        public int GetRestriction()
        {
            return Restriction;
        }

    }
}
