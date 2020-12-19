using Backend.Medications.Model;
using System.Collections.Generic;
using System.Windows.Controls;


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
