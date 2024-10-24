using ManageLibrary_Domain.Abstract;

namespace ManageLibrary_Application.DTOs {
    public class BookDTO : Base{
        public string Name { get; set; }
        public string Author { get; set; }
        public int AvailableQuantity { get; set; }
    }
}
