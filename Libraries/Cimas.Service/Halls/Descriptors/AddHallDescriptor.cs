namespace Cimas.Service.Halls.Descriptors
{
    public class AddHallDescriptor
    {
        public int CinemaId { get; set; }
        public string Name { get; set; }

        public int Rows { get; set; }
        public int Columns { get; set; }
    }
}
