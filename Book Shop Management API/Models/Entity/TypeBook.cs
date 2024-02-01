using static Book_Shop_Management_API.Helper.Enum.Enum;

namespace Book_Shop_Management_API.Models.Entity
{
    public class TypeBook
    {
        public int TypeBookId { get; set; }
        public string Name { get; set; }

        public bookType bookType { get; set; }
        public virtual List<Book> Books { get; set; }

    }
}
