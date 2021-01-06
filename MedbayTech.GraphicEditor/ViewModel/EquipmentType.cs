

namespace GraphicEditor.ViewModel
{
    public class EquipmentType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public EquipmentType()
        {
        }

        public EquipmentType(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
