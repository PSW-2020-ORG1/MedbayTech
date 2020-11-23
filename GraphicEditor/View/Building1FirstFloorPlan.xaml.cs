﻿using System;
using System.Collections.Generic;
using System.IO;
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

namespace GraphicEditor.View.Building1
{
    /// <summary>
    /// Interaction logic for Building1FirstFloorPlan.xaml
    /// </summary>
    public partial class Building1FirstFloorPlan : Page
    {
        public Building1FirstFloorPlan()
        {
            InitializeComponent();
        }
        public Building1FirstFloorPlan(MainPage mainPage)
        {
            InitializeComponent();
            page = mainPage;
        }
        MainPage page;
        public void Building1Objects(object sender, RoutedEventArgs e)
        {
            List<Rectangle> rectangles = new List<Rectangle>();

            string textFile = "C:/Users/Korisnik DT/Documents/GitHub/MedbayTech/MapData/Hospital1Floor1.txt";
            MapObject o = new MapObject();
            rectangles = o.Window_Loaded(textFile, canvasH1F1);
            foreach (Rectangle rectangle in rectangles)
            {
                if(rectangle.Name.Equals("PatientRoom"))
                {
                    rectangle.MouseDown += AdditionalInformationPatientRoom;
                    rectangle.MouseEnter += PatientRoom_MouseEnter;
                    rectangle.MouseLeave += PatientRoom_MouseLeave;
                }
                else if(rectangle.Name.Equals("ExaminationRoom"))
                {
                    rectangle.MouseDown += AdditionalInformationExaminationRoom;
                    rectangle.MouseEnter += ExaminationRoom_MouseEnter;
                    rectangle.MouseLeave += ExaminationRoom_MouseLeave;
                }
                else if (rectangle.Name.Equals("OperatingRoom"))
                {
                    rectangle.MouseDown += AdditionalInformationOperatingRoom;
                    rectangle.MouseEnter += OperatingRoom_MouseEnter;
                    rectangle.MouseLeave += OperatingRoom_MouseLeave;
                }
                else if (rectangle.Name.Equals("AuxiliaryRoom"))
                {
                    rectangle.MouseDown += AdditionalInformationAuxiliaryRoom;
                    rectangle.MouseEnter += AuxiliaryRoom_MouseEnter;
                    rectangle.MouseLeave += AuxiliaryRoom_MouseLeave;
                }
                else if (rectangle.Name.Equals("StorageRoom"))
                {
                    rectangle.MouseDown += AdditionalInformationAuxiliaryRoom;
                    rectangle.MouseEnter += AuxiliaryRoom_MouseEnter;
                    rectangle.MouseLeave += AuxiliaryRoom_MouseLeave;
                }
            }

        }
        private void mouseClickArrowUp(object sender, MouseButtonEventArgs e)
        {
            page.MainFrame.Content = new Building1SecondFloorPlan();
            if (page.tabControl.SelectedIndex == 0)
            {
                page.comboBoxH1.SelectedIndex = 2;
            }
            else
            {
                page.comboBoxHospital1.SelectedIndex = 2;
            }
        }
        private void mouseClickArrowDown(object sender, MouseButtonEventArgs e)
        {
            page.MainFrame.Content = new Building1FloorPlan();
            if (page.tabControl.SelectedIndex == 0)
            {
                page.comboBoxH1.SelectedIndex = 0;
            }
            else
            {
                page.comboBoxHospital1.SelectedIndex = 0;
            }
        }

        private void PatientRoom_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ChooseUser.Restriction == 0)
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
            if (ChooseUser.Restriction == 0)
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
            if (ChooseUser.Restriction == 0)
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
            if (ChooseUser.Restriction == 0)
            {
                AdditionalInformationPatientRoom additionalInformation = new AdditionalInformationPatientRoom();
                additionalInformation.ShowDialog();
            }
        }

        private void AdditionalInformationOperatingRoom(object sender, MouseButtonEventArgs e)
        {
            if (ChooseUser.Restriction == 0)
            {
                AdditionalInformationOperatingRoom additionalInformation = new AdditionalInformationOperatingRoom();
                additionalInformation.ShowDialog();
            }
        }

        private void AdditionalInformationExaminationRoom(object sender, MouseButtonEventArgs e)
        {
            if (ChooseUser.Restriction == 0)
            {
                AdditionalInformationExaminationRoom additionalInformation = new AdditionalInformationExaminationRoom();
                additionalInformation.ShowDialog();
            }
        }

        private void AdditionalInformationAuxiliaryRoom(object sender, MouseButtonEventArgs e)
        {
            if (ChooseUser.Restriction == 0)
            {
                AdditionalInformationAuxiliaryRoom additionalInformation = new AdditionalInformationAuxiliaryRoom();
                additionalInformation.ShowDialog();
            }
        }
    }
}
