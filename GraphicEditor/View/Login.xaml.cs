using System;
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

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }
        public Login(MainWindow mainWindow)
        {
            InitializeComponent();
            window = mainWindow;
        }
        MainWindow window;

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            window.Frame.Content = new MainPage(window);
        }
    }

}
