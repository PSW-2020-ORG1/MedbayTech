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
    /// Interaction logic for SearchResaultsForEquipment.xaml
    /// </summary>
    public partial class SearchResaultsForEquipment : Page
    {
        public SearchResaultsForEquipment()
        {
            InitializeComponent();
        }
        MainPage page;
        public SearchResaultsForEquipment(MainPage mainPage)
        {
            InitializeComponent();
            page = mainPage;
        }
    }
}
