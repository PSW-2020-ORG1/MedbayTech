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
    class Rectt
    {
        public String Id { get; set; }
        public String RoomType { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public SolidColorBrush Color { get; set; }
    }
    class MapObject
    {

        public MapObject()
        {

        }

        public SolidColorBrush Border { get; private set; }

        public List<Rectt> LoadFromFile(string textFile)
        {
            List<Rectt> rectangles = new List<Rectt>();

            if (File.Exists(textFile))
            {
                // Read a text file line by line.  
                string[] lines = File.ReadAllLines(textFile);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                  //  byte b1 = Byte.Parse(parts[6]);
                   // byte b2 = Byte.Parse(parts[7]);
                    //byte b3 = Byte.Parse(parts[8]);

                    //Color col = Color.FromRgb(b1, b2, b3);

                    rectangles.Add(new Rectt()
                    {
                        Id = parts[0],
                        RoomType = parts[1],
                        Width = Int32.Parse(parts[2]),
                        Height = Int32.Parse(parts[3]),
                        Left = Int32.Parse(parts[4]),
                        Top = Int32.Parse(parts[5])

                    });
                }
            }
            return rectangles;
        }
        public List<Rectangle> Window_Loaded(string textFile, Canvas canvas)
        {
            // ... Create list of our Rect objects.
            List<Rectt> rects = new List<Rectt>();
            rects = LoadFromFile(textFile);

            List<Rectangle> rectangles = new List<Rectangle>();
            foreach (Rectt rect in rects)
            {
                // ... Create Rectangle object.
                Rectangle r = new Rectangle();
                r.Uid = rect.Id;
                r.Name = rect.RoomType;
                r.Width = rect.Width;
                r.Height = rect.Height;
                Color Black = Color.FromRgb(0, 0, 0);
                Border = new SolidColorBrush(Black);
                if (rect.RoomType.Equals("PatientRoom"))
                {
                    r.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#dca0d3");
                }
                else if(rect.RoomType.Equals("ExaminationRoom"))
                {
                    r.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#77c588");
                }
                else if (rect.RoomType.Equals("OperatingRoom"))
                {
                    r.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#208e38");
                }
                else if (rect.RoomType.Equals("StorageRoom"))
                {
                    r.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#ffdf99");
                }
                else if (rect.RoomType.Equals("AuxiliaryRoom"))
                {
                    r.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#9da49f");
                }
                r.Stroke = Border;
                r.StrokeThickness = 3;

                // ... Set canvas position based on Rect object.
                Canvas.SetLeft(r, rect.Left);
                Canvas.SetTop(r, rect.Top);
                // ... Add to canvas.
                canvas.Children.Add(r);

                rectangles.Add(r);
            }
            return rectangles;
        }
    }
}
