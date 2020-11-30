using Model.Rooms;
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
    /// Interaction logic for AdditionalInformationAuxiliaryRoomEquipment.xaml
    /// </summary>
    public partial class AdditionalInformationAuxiliaryRoomEquipment : Page
    {
        public AdditionalInformationAuxiliaryRoomEquipment(List<HospitalEquipment> hospitalEquipment)
        {
            InitializeComponent();
            dataGridEquipment.ItemsSource = hospitalEquipment;
        }
    }
}
