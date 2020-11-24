using GraphicEditor.View.Building2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for Building2FloorPlan.xaml
    /// </summary>
    public partial class Building2FloorPlan : Page
    {
        private MainPage page;

        public Building2FloorPlan(MainPage mainPage)
        {
            InitializeComponent();
            page = mainPage;
        }

        private void mouseClickArrowUp(object sender, MouseButtonEventArgs e)
        {
            page.MainFrame.Content = new Building2FirstFloorPlan(page);
            if (page.tabControl.SelectedIndex == 0)
            {
                page.comboBoxH2.SelectedIndex = 1;
            }
            else
            {
                page.comboBoxHospital2.SelectedIndex = 1;
            }
        }

        private void PatientRoom_MouseEnter(object sender, MouseEventArgs e)
        {
            if (page.getRestriction() == 0)
            {
                PopupPatientRoom.Placement = PlacementMode.MousePoint;
                PopupPatientRoom.IsOpen = true;
            }
            else
            {
                PopupInfoForPatient.Placement = PlacementMode.MousePoint;
                PopupInfoForPatient.IsOpen = true;
            }
        }

        private void PatientRoom_MouseLeave(object sender, MouseEventArgs e)
        {
            PopupPatientRoom.Visibility = Visibility.Collapsed;
            PopupPatientRoom.IsOpen = false;

            PopupInfoForPatient.Visibility = Visibility.Collapsed;
            PopupInfoForPatient.IsOpen = false;
        }

        private void ExaminationRoom_MouseEnter(object sender, MouseEventArgs e)
        {
            PopupExaminationRoom.Placement = PlacementMode.MousePoint;
            PopupExaminationRoom.IsOpen = true;
        }

        private void ExaminationRoom_MouseLeave(object sender, MouseEventArgs e)
        {
            PopupExaminationRoom.Visibility = Visibility.Collapsed;
            PopupExaminationRoom.IsOpen = false;
        }

        private void OperatingRoom_MouseEnter(object sender, MouseEventArgs e)
        {
            if (page.getRestriction() == 0)
            {
                PopupOperatingRoom.Placement = PlacementMode.MousePoint;
                PopupOperatingRoom.IsOpen = true;
            }
            else
            {
                PopupInfoForPatient.Placement = PlacementMode.MousePoint;
                PopupInfoForPatient.IsOpen = true;
            }
        }

        private void OperatingRoom_MouseLeave(object sender, MouseEventArgs e)
        {
            PopupOperatingRoom.Visibility = Visibility.Collapsed;
            PopupOperatingRoom.IsOpen = false;

            PopupInfoForPatient.Visibility = Visibility.Collapsed;
            PopupInfoForPatient.IsOpen = false;
        }

        private void AuxiliaryRoom_MouseEnter(object sender, MouseEventArgs e)
        {
            if (page.getRestriction() == 0)
            {
                PopupAuxiliaryRoom.Placement = PlacementMode.MousePoint;
                PopupAuxiliaryRoom.IsOpen = true;
            }
            else
            {
                PopupInfoForPatient.Placement = PlacementMode.MousePoint;
                PopupInfoForPatient.IsOpen = true;
            }
        }

        private void AuxiliaryRoom_MouseLeave(object sender, MouseEventArgs e)
        {
            PopupAuxiliaryRoom.Visibility = Visibility.Collapsed;
            PopupAuxiliaryRoom.IsOpen = false;

            PopupInfoForPatient.Visibility = Visibility.Collapsed;
            PopupInfoForPatient.IsOpen = false;
        }

        private void AdditionalInformationPatientRoom(object sender, MouseButtonEventArgs e)
        {
            if (page.getRestriction() == 0)
            {
                AdditionalInformationPatientRoom additionalInformation = new AdditionalInformationPatientRoom();
                additionalInformation.ShowDialog();
            }
        }

        private void AdditionalInformationOperatingRoom(object sender, MouseButtonEventArgs e)
        {
            if (page.getRestriction() == 0)
            {
                AdditionalInformationOperatingRoom additionalInformation = new AdditionalInformationOperatingRoom();
                additionalInformation.ShowDialog();
            }
        }

        private void AdditionalInformationExaminationRoom(object sender, MouseButtonEventArgs e)
        {
            if (page.getRestriction() == 0)
            {
                AdditionalInformationExaminationRoom additionalInformation = new AdditionalInformationExaminationRoom();
                additionalInformation.ShowDialog();
            }
        }

        private void AdditionalInformationAuxiliaryRoom(object sender, MouseButtonEventArgs e)
        {
            if (page.getRestriction() == 0)
            {
                AdditionalInformationAuxiliaryRoom additionalInformation = new AdditionalInformationAuxiliaryRoom();
                additionalInformation.ShowDialog();
            }
        }

    }
}
