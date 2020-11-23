using System;
using System.Collections.Generic;
using System.Text;
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
    /// Interaction logic for SearchResultsForRooms.xaml
    /// </summary>
    public partial class SearchResultsForRooms : Page
    {
        public SearchResultsForRooms()
        {
            InitializeComponent();
        }
        MainPage page;
        public SearchResultsForRooms(MainPage mainPage)
        {
            InitializeComponent();
            page = mainPage;
        }
    }
}
