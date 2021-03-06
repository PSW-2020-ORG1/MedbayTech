﻿using GraphicEditor.ViewModel;
using System.Collections.Generic;
using System.Windows.Controls;

namespace MedbayTech.GraphicEditor.View
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
