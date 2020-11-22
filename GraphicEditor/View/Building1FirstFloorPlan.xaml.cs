using System;
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
                }
                else if(rectangle.Name.Equals("ExamintionRoom"))
                {
                    rectangle.MouseDown += AdditionalInformationExaminationRoom;
                }
                else if (rectangle.Name.Equals("OperatingRoom"))
                {
                    rectangle.MouseDown += AdditionalInformationOperatingRoom;
                }
                else if (rectangle.Name.Equals("AuxiliaryRoom"))
                {
                    rectangle.MouseDown += AdditionalInformationAuxiliaryRoom;
                }
                else if (rectangle.Name.Equals("StorageRoom"))
                {
                    rectangle.MouseDown += AdditionalInformationAuxiliaryRoom;
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
