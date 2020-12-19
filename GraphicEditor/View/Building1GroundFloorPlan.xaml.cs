using GraphicEditor.View;
using GraphicEditor.View.Building1;
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

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for Building1FloorPlan.xaml
    /// </summary>
    public partial class Building1FloorPlan : Page
    {
        private MainPage page;

        public Building1FloorPlan(MainPage mainPage)
        {
            InitializeComponent();
            page = mainPage;
            string path = Directory.GetCurrentDirectory();
            string new_path = path.Replace('\\', '/');
            string arrowUp = new_path + "/Icons/arrowUp.png";
            imageArrowUp.Source = new BitmapImage(new Uri(@arrowUp, UriKind.Absolute));
        }
        public void Building1Objects(object sender, RoutedEventArgs e)
        {
            List<System.Windows.Shapes.Rectangle> rectangles = new List<System.Windows.Shapes.Rectangle>();

            string textFile = "MapData/Hospital1GroundFloor.txt";
            MapObject o = new MapObject();
            rectangles = o.Window_Loaded(textFile, canvasH1GF);
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
                if (rectangle.Uid.Equals(SearchAppointment.Id))
                {
                    rectangle.Stroke = (SolidColorBrush)new BrushConverter().ConvertFromString("#33ff49");
                    rectangle.StrokeThickness = 5;
                    SearchAppointment.Id = "0";
                }
            }
        }

        private void mouseClickArrowUp(object sender, RoutedEventArgs e)
        {
            page.MainFrame.Content = new Building1FirstFloorPlan(page);
            if (page.tabControl.SelectedIndex == 0)
            {
                page.comboBoxH1.SelectedIndex = 1;
            }
            else
            {
                page.comboBoxHospital1.SelectedIndex = 1;
            }
        }

        private void PatientRoom_MouseEnter(object sender, MouseEventArgs e)
        {
            System.Windows.Shapes.Rectangle r = (System.Windows.Shapes.Rectangle)sender;
            int roomId = Int32.Parse(r.Uid);
            if (page.getRestriction() != 1)
            {
                PopupPatientRoom.Placement = PlacementMode.MousePoint;
                PopupPatientRoom.DataContext = page.SearchDataBaseForRoom(roomId);
                PopupPatientRoom.IsOpen = true;
            }
            else
            {
                PopupInfoForPatient.Placement = PlacementMode.MousePoint;
                PopupInfoForPatient.DataContext = page.SearchDataBaseForRoom(roomId);
                PopupInfoForPatient.IsOpen = true;
            }
        }

        private void PatientRoom_MouseLeave(object sender, MouseEventArgs e)
        {
            PopupPatientRoom.Visibility = PopupInfoForPatient.Visibility = Visibility.Collapsed;
            PopupPatientRoom.IsOpen = PopupInfoForPatient.IsOpen = false;
        }

        private void ExaminationRoom_MouseEnter(object sender, MouseEventArgs e)
        {
            System.Windows.Shapes.Rectangle r = (System.Windows.Shapes.Rectangle)sender;
            int roomId = Int32.Parse(r.Uid);
            if(page.getRestriction() != 1)
            {
                PopupExaminationRoom.Placement = PlacementMode.MousePoint;
                PopupExaminationRoom.DataContext = page.searchDataBaseForDoctor(roomId);
                PopupExaminationRoom.IsOpen = true;
            }
            else
            {
                PopupInfoForPatient.Placement = PlacementMode.MousePoint;
                PopupInfoForPatient.DataContext = page.SearchDataBaseForRoom(roomId);
                PopupInfoForPatient.IsOpen = true;
            }
        }

        private void ExaminationRoom_MouseLeave(object sender, MouseEventArgs e)
        {
            PopupExaminationRoom.Visibility = PopupInfoForPatient.Visibility = Visibility.Collapsed;
            PopupExaminationRoom.IsOpen = PopupInfoForPatient.IsOpen = false;
        }

        private void OperatingRoom_MouseEnter(object sender, MouseEventArgs e)
        {
            System.Windows.Shapes.Rectangle r = (System.Windows.Shapes.Rectangle)sender;
            int roomId = Int32.Parse(r.Uid);
            if (page.getRestriction() != 1)
            {
                PopupOperatingRoom.Placement = PlacementMode.MousePoint;
                PopupOperatingRoom.DataContext = page.SearchDataBaseForRoom(roomId);
                PopupOperatingRoom.IsOpen = true;
            }
            else
            {
                PopupInfoForPatient.Placement = PlacementMode.MousePoint;
                PopupInfoForPatient.DataContext = page.SearchDataBaseForRoom(roomId);
                PopupInfoForPatient.IsOpen = true;
            }
        }

        private void OperatingRoom_MouseLeave(object sender, MouseEventArgs e)
        {
            PopupOperatingRoom.Visibility = PopupInfoForPatient.Visibility = Visibility.Collapsed;
            PopupOperatingRoom.IsOpen = PopupInfoForPatient.IsOpen = false;
        }

        private void AuxiliaryRoom_MouseEnter(object sender, MouseEventArgs e)
        {
            System.Windows.Shapes.Rectangle r = (System.Windows.Shapes.Rectangle)sender;
            int roomId = Int32.Parse(r.Uid);
            if (page.getRestriction() != 1)
            {
                PopupAuxiliaryRoom.Placement = PlacementMode.MousePoint;
                PopupAuxiliaryRoom.DataContext = page.SearchDataBaseForRoom(roomId);
                PopupAuxiliaryRoom.IsOpen = true;
            }
            else
            {
                PopupInfoForPatient.Placement = PlacementMode.MousePoint;
                PopupInfoForPatient.DataContext = page.SearchDataBaseForRoom(roomId);
                PopupInfoForPatient.IsOpen = true;
            }
        }

        private void AuxiliaryRoom_MouseLeave(object sender, MouseEventArgs e)
        {
            PopupAuxiliaryRoom.Visibility = PopupInfoForPatient.Visibility = Visibility.Collapsed;
            PopupAuxiliaryRoom.IsOpen = PopupInfoForPatient.IsOpen = false;
        }

        private void AdditionalInformationPatientRoom(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Shapes.Rectangle r = (System.Windows.Shapes.Rectangle)sender;
            int roomId = Int32.Parse(r.Uid);
            if (page.getRestriction() != 1)
            {
                AdditionalInformationPatientRoom additionalInformation = new AdditionalInformationPatientRoom(roomId);
                additionalInformation.ShowDialog();
            }
        }

        private void AdditionalInformationOperatingRoom(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Shapes.Rectangle r = (System.Windows.Shapes.Rectangle)sender;
            int roomId = Int32.Parse(r.Uid);
            if (page.getRestriction() != 1)
            {
                AdditionalInformationOperatingRoom additionalInformation = new AdditionalInformationOperatingRoom(roomId);
                additionalInformation.ShowDialog();
            }
        }

        private void AdditionalInformationExaminationRoom(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Shapes.Rectangle r = (System.Windows.Shapes.Rectangle)sender;
            int roomId = Int32.Parse(r.Uid);
            if (page.getRestriction() != 1)
            {
                AdditionalInformationExaminationRoom additionalInformation = new AdditionalInformationExaminationRoom(roomId);
                additionalInformation.ShowDialog();
            }
        }

        private void AdditionalInformationAuxiliaryRoom(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Shapes.Rectangle r = (System.Windows.Shapes.Rectangle)sender;
            int roomId = Int32.Parse(r.Uid);
            if (page.getRestriction() != 1)
            {
                AdditionalInformationAuxiliaryRoom additionalInformation = new AdditionalInformationAuxiliaryRoom(roomId);
                additionalInformation.ShowDialog();
            }
        }
    }
}
