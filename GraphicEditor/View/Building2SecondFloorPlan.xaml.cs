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

namespace GraphicEditor.View.Building2
{
    /// <summary>
    /// Interaction logic for Building2SecondFloorPlan.xaml
    /// </summary>
    public partial class Building2SecondFloorPlan : Page
    {
        private MainPage page;

        public Building2SecondFloorPlan(MainPage mainPage)
        {
            InitializeComponent();
            page = mainPage;
            string path = Directory.GetCurrentDirectory();
            string new_path = path.Replace('\\', '/');
            string arrowDown = new_path + "/View/arrowDown.png";
            imageArrowDown.Source = new BitmapImage(new Uri(@arrowDown, UriKind.Absolute));
        }


        public void Building2Objects(object sender, RoutedEventArgs e)
        {
            List<System.Windows.Shapes.Rectangle> rectangles = new List<System.Windows.Shapes.Rectangle>();

            string textFile = "MapData/Hospital2Floor2.txt";
            MapObject o = new MapObject();
            rectangles = o.Window_Loaded(textFile, canvasBuild2fl1);
            foreach (System.Windows.Shapes.Rectangle rectangle in rectangles)
            {
                if (rectangle.Name.Equals("PatientRoom"))
                {
                    rectangle.MouseDown += AdditionalInformationPatientRoom;
                    rectangle.MouseEnter += PatientRoom_MouseEnter;
                    rectangle.MouseLeave += PatientRoom_MouseLeave;
                }
                else if (rectangle.Name.Equals("ExaminationRoom"))
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

                if (rectangle.Uid.Equals(SearchResultsForRooms.Id))
                {
                    rectangle.Stroke = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff1f1f");
                    rectangle.StrokeThickness = 5;
                    SearchResultsForRooms.Id = "0";
                }

                if (rectangle.Uid.Equals(SearchResultsForMedicines.Id))
                {
                    rectangle.Stroke = (SolidColorBrush)new BrushConverter().ConvertFromString("#0022ff");
                    rectangle.StrokeThickness = 5;
                    SearchResultsForMedicines.Id = "0";
                }
                if (rectangle.Uid.Equals(SearchResultsForEquipment.Id))
                {
                    rectangle.Stroke = (SolidColorBrush)new BrushConverter().ConvertFromString("#ffea05");
                    rectangle.StrokeThickness = 5;
                    SearchResultsForEquipment.Id = "0";
                }
            }
        }

        private void mouseClickArrowDown(object sender, RoutedEventArgs e)
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
            PopupPatientRoom.Placement = PlacementMode.MousePoint;
            PopupPatientRoom.IsOpen = true;
        }

        private void PatientRoom_MouseLeave(object sender, MouseEventArgs e)
        {
            PopupPatientRoom.Visibility = Visibility.Collapsed;
            PopupPatientRoom.IsOpen = false;
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
            PopupOperatingRoom.Placement = PlacementMode.MousePoint;
            PopupOperatingRoom.IsOpen = true;
        }

        private void OperatingRoom_MouseLeave(object sender, MouseEventArgs e)
        {
            PopupOperatingRoom.Visibility = Visibility.Collapsed;
            PopupOperatingRoom.IsOpen = false;
        }

        private void AuxiliaryRoom_MouseEnter(object sender, MouseEventArgs e)
        {
            PopupAuxiliaryRoom.Placement = PlacementMode.MousePoint;
            PopupAuxiliaryRoom.IsOpen = true;
        }

        private void AuxiliaryRoom_MouseLeave(object sender, MouseEventArgs e)
        {
            PopupAuxiliaryRoom.Visibility = Visibility.Collapsed;
            PopupAuxiliaryRoom.IsOpen = false;
        }

        private void AdditionalInformationPatientRoom(object sender, MouseButtonEventArgs e)
        {
            AdditionalInformationPatientRoom additionalInformation = new AdditionalInformationPatientRoom();
            additionalInformation.ShowDialog();
        }

        private void AdditionalInformationOperatingRoom(object sender, MouseButtonEventArgs e)
        {
            AdditionalInformationOperatingRoom additionalInformation = new AdditionalInformationOperatingRoom();
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
