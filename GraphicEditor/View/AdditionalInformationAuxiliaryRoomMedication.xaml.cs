using Backend.Medications.Model;
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

namespace GraphicEditor.View
{
    /// <summary>
    /// Interaction logic for AdditionalInformationAuxiliaryRoomMedication.xaml
    /// </summary>
    public partial class AdditionalInformationAuxiliaryRoomMedication : Page
    {
        public AdditionalInformationAuxiliaryRoomMedication(List<Medication> medications)
        {
            InitializeComponent();
            dataGridMedication.ItemsSource = medications;
        }
    }
}
