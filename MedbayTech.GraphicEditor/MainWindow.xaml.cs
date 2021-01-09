
using MedbayTech.GraphicEditor.View;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MedbayTech.GraphicEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            String userType = "administrator";
            //String userType = "patient";
            //String userType = "secretary";
            //String userType = "doctor";
            InitializeComponent();
            Frame.Content = new MainPage(userType, this);
        }
    }
}
