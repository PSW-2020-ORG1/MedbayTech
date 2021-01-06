using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace GraphicEditor
{
    class Rectangle
    {
        public String Id { get; set; }
        public String RoomType { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public SolidColorBrush Color { get; set; }
        
        public Rectangle(){}

        public Rectangle(String id, String roomType, int width, int height, int left, int top, SolidColorBrush color)
        {
            Id = id;
            RoomType = roomType;
            Width = width;
            Height = height;
            Left = left;
            Top = top;
            Color = color;
        }

        public Rectangle(String id, String roomType, int width, int height, int left, int top)
        {
            Id = id;
            RoomType = roomType;
            Width = width;
            Height = height;
            Left = left;
            Top = top;
        }
    }
    class MapObject
    {

        public MapObject()
        {

        }

        public SolidColorBrush Border { get; private set; }

        public List<Rectangle> LoadFromFile(string textFile)
        {
            List<Rectangle> rectangles = new List<Rectangle>();
            if (File.Exists(textFile))
            {
                string[] lines = File.ReadAllLines(textFile);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
            
                    rectangles.Add(new Rectangle(parts[0], parts[1], Int32.Parse(parts[2]), Int32.Parse(parts[3]), Int32.Parse(parts[4]),Int32.Parse(parts[5])));

                }
            }
            return rectangles;
        }
        public List<System.Windows.Shapes.Rectangle> Window_Loaded(string textFile, Canvas canvas)
        {
            List<Rectangle> rectanglesFromFile = LoadFromFile(textFile);

            List<System.Windows.Shapes.Rectangle> rectangles = new List<System.Windows.Shapes.Rectangle>();
            foreach (Rectangle rectangle in rectanglesFromFile)
            {
                System.Windows.Shapes.Rectangle newRectangle = new System.Windows.Shapes.Rectangle();
                newRectangle.Uid = rectangle.Id;
                newRectangle.Name = rectangle.RoomType;
                newRectangle.Width = rectangle.Width;
                newRectangle.Height = rectangle.Height;
                Color black = Color.FromRgb(0, 0, 0);
                Border = new SolidColorBrush(black);
                if (rectangle.RoomType.Equals("PatientRoom"))
                {
                    newRectangle.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#dca0d3");
                }
                else if(rectangle.RoomType.Equals("ExaminationRoom"))
                {
                    newRectangle.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#77c588");
                }
                else if (rectangle.RoomType.Equals("OperatingRoom"))
                {
                    newRectangle.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#208e38");
                }
                else if (rectangle.RoomType.Equals("StorageRoom"))
                {
                    newRectangle.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#ffdf99");
                }
                else if (rectangle.RoomType.Equals("AuxiliaryRoom"))
                {
                    newRectangle.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#9da49f");
                }
                else if (rectangle.RoomType.Equals("Elevator"))
                {
                    newRectangle.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#484848");
                }
                newRectangle.Stroke = Border;
                newRectangle.StrokeThickness = 3;

                Canvas.SetLeft(newRectangle, rectangle.Left);
                Canvas.SetTop(newRectangle, rectangle.Top);

                canvas.Children.Add(newRectangle);

                rectangles.Add(newRectangle);
            }
            return rectangles;
        }
    }
}
