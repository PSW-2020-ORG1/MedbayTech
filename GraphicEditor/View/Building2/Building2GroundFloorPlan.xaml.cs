﻿using GraphicEditor.View.Building2;
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
        private MainWindow mainWindow;

        public Building2FloorPlan(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void mouseClickArrowUp(object sender, MouseButtonEventArgs e)
        {
            mainWindow.MainFrame.Content = new Building2FirstFloorPlan(mainWindow);
            if (mainWindow.tabControl.SelectedIndex == 0)
            {
                mainWindow.comboBoxH2.SelectedIndex = 1;
            }
            else
            {
                mainWindow.comboBoxHospital2.SelectedIndex = 1;
            }
        }

        private void ExaminationRoom_MouseEnter(object sender, MouseEventArgs e)
        {
            PopupExaminationRoom.Placement = PlacementMode.MousePoint;
            PopupExaminationRoom.IsOpen = true;
        }

        private void PatientRoom_MouseEnter(object sender, MouseEventArgs e)
        {
            PopupPatientRoom.Visibility = Visibility.Collapsed;
            PopupPatientRoom.IsOpen = false;
        }

        private void AuxiliaryRoom_MouseEnter(object sender, MouseEventArgs e)
        {
            PopupAuxiliaryRoom.Placement = PlacementMode.MousePoint;
            PopupAuxiliaryRoom.IsOpen = true;
        }

        private void PatientRoom_MouseLeave(object sender, MouseEventArgs e)
        {
            PopupPatientRoom.Visibility = Visibility.Collapsed;
            PopupPatientRoom.IsOpen = false;
        }

        private void AuxiliaryRoom_MouseLeave(object sender, MouseEventArgs e)
        {
            PopupAuxiliaryRoom.Visibility = Visibility.Collapsed;
            PopupAuxiliaryRoom.IsOpen = false;
        }

        private void ExaminationRoom_MouseLeave(object sender, MouseEventArgs e)
        {
            PopupExaminationRoom.Visibility = Visibility.Collapsed;
            PopupExaminationRoom.IsOpen = false;
        }
        private void OperatingRoom_MouseEnter(object sender, MouseEventArgs e)
        {
            PopupOperatingRoom.Placement = PlacementMode.MousePoint;
            PopupOperatingRoom.IsOpen = true;
        }

        private void OperatingRoom_MouseLeave(object sender, MouseEventArgs e)
        {
            PopupOperatingRoom.Visibility = Visibility.Collapsed;
            PopupOperatingRoom.IsOpen = false;
        }

        private void AdditionalInformationPatientRoom(object sender, MouseButtonEventArgs e)
        {
            AdditionalInformationPatientRoom additionalInformation = new AdditionalInformationPatientRoom();
            additionalInformation.ShowDialog();
        }

        private void AdditionalInformationOperatingRoom(object sender, MouseButtonEventArgs e)
        {
            AdditionalInformationOperaingRoom additionalInformation = new AdditionalInformationOperaingRoom();
            additionalInformation.ShowDialog();
        }

        private void AdditionalInformationExaminationRoom(object sender, MouseButtonEventArgs e)
        {
            AdditionalInformationExaminationRoom additionalInformation = new AdditionalInformationExaminationRoom();
            additionalInformation.ShowDialog();
        }

        private void AdditionalInformationAuxiliaryRoom(object sender, MouseButtonEventArgs e)
        {
            AdditionalInformationAuxiliaryRoom additionalInformation = new AdditionalInformationAuxiliaryRoom();
            additionalInformation.ShowDialog();
        }

    }
}
