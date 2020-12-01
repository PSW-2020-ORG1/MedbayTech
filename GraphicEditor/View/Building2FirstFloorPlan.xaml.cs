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
    /// Interaction logic for Building2FirstFloorPlan.xaml
    /// </summary>
    public partial class Building2FirstFloorPlan : Page
    {
        private MainPage page;

        public Building2FirstFloorPlan(MainPage mainPage)
        {
            InitializeComponent();
            page = mainPage;
            string path = Directory.GetCurrentDirectory();
            string new_path = path.Replace('\\', '/');
            string arrowUp = new_path + "/View/arrowUp.png";
            string arrowDown = new_path + "/View/arrowDown.png";
            imageArrowUp.Source = new BitmapImage(new Uri(@arrowUp, UriKind.Absolute));
            imageArrowDown.Source = new BitmapImage(new Uri(@arrowDown, UriKind.Absolute));
        }

        public void Building2Objects(object sender, RoutedEventArgs e)
        {
            List<System.Windows.Shapes.Rectangle> rectangles = new List<System.Windows.Shapes.Rectangle>();

            string textFile = "MapData/Hospital2Floor1.txt";
            MapObject o = new MapObject();
            rectangles = o.Window_Loaded(textFile, canvasBuild1fl1);
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
        private void mouseClickArrowUp(object sender, MouseButtonEventArgs e)
        {
            page.MainFrame.Content = new Building2SecondFloorPlan(page);
            if (page.tabControl.SelectedIndex == 0)
            {
                page.comboBoxH2.SelectedIndex = 2;
            }
            else
            {
                page.comboBoxHospital2.SelectedIndex = 2;
            }
        }
        private void mouseClickArrowDown(object sender, MouseButtonEventArgs e)
        {
            page.MainFrame.Content = new Building1FloorPlan(page);
            if (page.tabControl.SelectedIndex == 0)
            {
                page.comboBoxH2.SelectedIndex = 0;
            }
            else
            {
                page.comboBoxHospital2.SelectedIndex = 0;
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
            System.Windows.Shapes.Rectangle r = (System.Windows.Shapes.Rectangle)sender;
            int roomId = Int32.Parse(r.Uid);
            if (page.getRestriction() == 0)
            {
                AdditionalInformationPatientRoom additionalInformation = new AdditionalInformationPatientRoom(roomId);
                additionalInformation.ShowDialog();
            }
        }

        private void AdditionalInformationOperatingRoom(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Shapes.Rectangle r = (System.Windows.Shapes.Rectangle)sender;
            int roomId = Int32.Parse(r.Uid);
            if(page.getRestriction() == 0)
            {
                AdditionalInformationOperatingRoom additionalInformation = new AdditionalInformationOperatingRoom(roomId);
                additionalInformation.ShowDialog();
            }
        }

        private void AdditionalInformationExaminationRoom(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Shapes.Rectangle r = (System.Windows.Shapes.Rectangle)sender;
            int roomId = Int32.Parse(r.Uid);
            if (page.getRestriction() == 0)
            {
                AdditionalInformationExaminationRoom additionalInformation = new AdditionalInformationExaminationRoom(roomId);
                additionalInformation.ShowDialog();
            }
        }

        private void AdditionalInformationAuxiliaryRoom(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Shapes.Rectangle r = (System.Windows.Shapes.Rectangle)sender;
            int roomId = Int32.Parse(r.Uid);
            if (page.getRestriction() == 0)
            {
                AdditionalInformationAuxiliaryRoom additionalInformation = new AdditionalInformationAuxiliaryRoom(roomId);
                additionalInformation.ShowDialog();
            }
        }
    }
}
