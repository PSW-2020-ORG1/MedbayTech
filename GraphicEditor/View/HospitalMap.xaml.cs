using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for HospitalMap.xaml
    /// </summary>
    public partial class HospitalMap : Page
    {
        public HospitalMap()
        {
            InitializeComponent();
        }
        public HospitalMap(MainWindow mainWindow)
        {
            InitializeComponent();
            window = mainWindow;
        }
        MainWindow window;

        private void Canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Canvas canvas = sender as Canvas;
            SizeChangedEventArgs canvas_Changed_Args = e;

            if (canvas_Changed_Args.PreviousSize.Width == 0) return;

            double old_Height = canvas_Changed_Args.PreviousSize.Height;

            double new_Height = canvas_Changed_Args.NewSize.Height;

            double old_Width = canvas_Changed_Args.PreviousSize.Width;

            double new_Width = canvas_Changed_Args.NewSize.Width;



            double scale_Width = new_Width / old_Width;

            double scale_Height = new_Height / old_Height;


            foreach (FrameworkElement element in canvas.Children)
            {
                double old_Left = Canvas.GetLeft(element);

                double old_Top = Canvas.GetTop(element);

                //double old_Right = Canvas.GetRight(element);

                //double old_Bottom = Canvas.GetBottom(element);


                Canvas.SetLeft(element, old_Left * scale_Width);

                Canvas.SetTop(element, old_Top * scale_Height);

                //Canvas.SetRight(element, old_Right * scale_Width);

                //Canvas.SetBottom(element, old_Bottom * scale_Height);


                element.Width = element.Width * scale_Width;

                element.Height = element.Height * scale_Height;

            }
        }

        private void ShowBuilding1FloorPlan(object sender, MouseButtonEventArgs e)
        {
            window.MainFrame.Content = new Building1FloorPlan(window);
            window.comboBoxH1.SelectedIndex = 0;
            window.SetActiveUserControl(window.legenda);
            Storyboard storyboard = new Storyboard();
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = 1;
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            storyboard.Children.Add(doubleAnimation);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(Canvas.OpacityProperty));
            Storyboard.SetTargetName(doubleAnimation, window.MainFrame.Name);
            storyboard.Begin(window);
        }

        private void ShowBuilding2FloorPlan(object sender, MouseButtonEventArgs e)
        {
            window.MainFrame.Content = new Building2FloorPlan(window);
            window.comboBoxH2.SelectedIndex = 0;
            window.SetActiveUserControl(window.legenda);
            Storyboard storyboard = new Storyboard();
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = 1;
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            storyboard.Children.Add(doubleAnimation);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(Canvas.OpacityProperty));
            Storyboard.SetTargetName(doubleAnimation, window.MainFrame.Name);
            storyboard.Begin(window);
        }
    }
}

