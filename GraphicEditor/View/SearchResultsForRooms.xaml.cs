using Model.Rooms;
using Newtonsoft.Json;
﻿using GraphicEditor.View.Building1;
using GraphicEditor.View.Building2;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for SearchResultsForRooms.xaml
    /// </summary>
    public partial class SearchResultsForRooms : Page
    {
        public SearchResultsForRooms()
        {
            InitializeComponent();
        }
        MainPage page;
        public SearchResultsForRooms(MainPage mainPage)
        {
            InitializeComponent();
            page = mainPage;
        }
        private void TransitionAnimation()
        {
            Storyboard storyboard = new Storyboard();
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = 1;
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            storyboard.Children.Add(doubleAnimation);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(Canvas.OpacityProperty));
            Storyboard.SetTargetName(doubleAnimation, page.MainFrame.Name);
            storyboard.Begin(page);
        }
        public SearchResultsForRooms(MainPage mainPage, string textBoxSearch)
        {
            InitializeComponent();
            page = mainPage;
            searchDataBase(textBoxSearch);
        }
        private void searchDataBase(string textBoxSearch)
        {
            List<Room> rooms = new List<Room>();
            if(textBoxSearch.Trim().Equals(""))
            {
                dataGridRoom.ItemsSource = rooms;
                MessageBox.Show("No results found!");
                return;
            }
            HttpClient httpClient = new HttpClient();
            var task = httpClient.GetAsync("http://localhost:53109/api/room/" + textBoxSearch + "/ByRoomLabelorRoomUse")
                .ContinueWith((taskWithResponse) =>
                {
                    var response = taskWithResponse.Result;
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    rooms = JsonConvert.DeserializeObject<List<Room>>(jsonString.Result);
                });
            task.Wait();
            dataGridRoom.ItemsSource = rooms;
            if(rooms.Count == 0) MessageBox.Show("No results found!");
        }
        public static string Id;
        private void buttonShowOnMap(object sender, RoutedEventArgs e)
        {
            Room room = (Room)dataGridRoom.SelectedItem;
            if (room == null)
            {
                MessageBox.Show("Nothing is selected!");
                return;
            }
            if(room.Department.Floor == 0 && room.Department.Hospital.Id == 1)
            {
                Id = room.Id.ToString();
                page.MainFrame.Content = new Building1FloorPlan(page);
                page.comboBoxH1.SelectedIndex = 0;
                page.comboBoxHospital1.SelectedIndex = 0;

                page.SetActiveUserControl(page.legenda);
                TransitionAnimation();
            }
            else if (room.Department.Floor == 1 && room.Department.Hospital.Id == 1)
            {
                Id = room.Id.ToString();
                page.MainFrame.Content = new Building1FirstFloorPlan(page);
                page.comboBoxH1.SelectedIndex = 1;
                page.comboBoxHospital1.SelectedIndex = 1;

                page.SetActiveUserControl(page.legenda);
                TransitionAnimation();
            }
            else if (room.Department.Floor == 2 && room.Department.Hospital.Id == 1)
            {
                Id = room.Id.ToString();
                page.MainFrame.Content = new Building1SecondFloorPlan(page);
                page.comboBoxH1.SelectedIndex = 2;
                page.comboBoxHospital1.SelectedIndex = 2;

                page.SetActiveUserControl(page.legenda);
                TransitionAnimation();
            }
            if (room.Department.Floor == 0 && room.Department.Hospital.Id == 2)
            {
                Id = room.Id.ToString();
                page.MainFrame.Content = new Building2FloorPlan(page);
                page.comboBoxH2.SelectedIndex = 0;
                page.comboBoxHospital2.SelectedIndex = 0;

                page.SetActiveUserControl(page.legenda);
                TransitionAnimation();
            }
            else if (room.Department.Floor == 1 && room.Department.Hospital.Id == 2)
            {
                Id = room.Id.ToString();
                page.MainFrame.Content = new Building2FirstFloorPlan(page);
                page.comboBoxH2.SelectedIndex = 1;
                page.comboBoxHospital2.SelectedIndex = 1;

                page.SetActiveUserControl(page.legenda);
                TransitionAnimation();
            }
            else if (room.Department.Floor == 2 && room.Department.Hospital.Id == 2)
            {
                Id = room.Id.ToString();
                page.MainFrame.Content = new Building2SecondFloorPlan(page);
                page.comboBoxH2.SelectedIndex = 2;
                page.comboBoxHospital2.SelectedIndex = 2;

                page.SetActiveUserControl(page.legenda);
                TransitionAnimation();
            }

        }
    }
}
