

namespace GraphicEditor.ViewModel
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public Hospital Hospital { get; set; }

        public Department()
        {
        }

        public Department(int id, string name, int floor, Hospital hospital)
        {
            Id = id;
            Name = name;
            Floor = floor;
            Hospital = hospital;
        }
    }
}
