
namespace GraphicEditor.ViewModel
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public Hospital()
        {
        }

        public Hospital(int id, string description, string name)
        {
            Id = id;
            Description = description;
            Name = name;
        }
    }

}
