using GraphicEditor.ViewModel;
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
using System.Windows.Shapes;

namespace MedbayTech.GraphicEditor.View
{
    /// <summary>
    /// Interaction logic for ScheduleRenovation.xaml
    /// </summary>
    public partial class ScheduleRenovation : Window
    {
        private Room room;
        public ScheduleRenovation(Room room)
        {
            InitializeComponent();
            this.room = room;
            textBoxFrom.IsEnabled = false;
            textBoxTo.IsEnabled = false;
            textBoxDescription.IsEnabled = false;
            dockPanelMerging.IsEnabled = false;
            dockPanelSeparating.IsEnabled = false;
            buttonScheduleRenovation.IsEnabled = false;
        }

        private void ButtonClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboBoxDoctor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(comboBoxDoctor.SelectedIndex == 0)
            {
                textBoxFrom.IsEnabled = true;
                textBoxTo.IsEnabled = true;
                textBoxDescription.IsEnabled = true;
                dockPanelMerging.IsEnabled = false;
                dockPanelSeparating.IsEnabled = false;
                buttonScheduleRenovation.IsEnabled = true;
            }
            else if(comboBoxDoctor.SelectedIndex == 1)
            {
                textBoxFrom.IsEnabled = true;
                textBoxTo.IsEnabled = true;
                textBoxDescription.IsEnabled = true;
                dockPanelMerging.IsEnabled = true;
                dockPanelSeparating.IsEnabled = false;
                buttonScheduleRenovation.IsEnabled = true;
            }
            else if (comboBoxDoctor.SelectedIndex == 2)
            {
                textBoxFrom.IsEnabled = true;
                textBoxTo.IsEnabled = true;
                textBoxDescription.IsEnabled = true;
                dockPanelMerging.IsEnabled = false;
                dockPanelSeparating.IsEnabled = true;
                buttonScheduleRenovation.IsEnabled = true;
            }
        }
    }
}
