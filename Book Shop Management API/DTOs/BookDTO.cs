namespace Book_Shop_Management_API.DTOs
{
    public class BookDTO
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime CreatedDate { get; set; }
        public string DurationDayAvaible { get; set; }
        public bool Isavailable { get; set; }
        public int Quantity { get; set; }
        public string Version { get; set; }
    }
}
