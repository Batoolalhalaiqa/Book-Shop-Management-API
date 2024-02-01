namespace Book_Shop_Management_API.Models.Entity
{
    public class Book
    {
        public int BookId { get; set; } 
        public string Title { get; set; } 
        public string Description { get; set; }
        public string Author { get; set; } 
        public DateTime CreatedDate { get; set; } 
        public string DurationDayAvaible { get; set; }

        public int Quantity { get; set; }
        public String Version { get; set; } 
        public virtual TypeBook TypeBook { get; set; } 
    }
}
