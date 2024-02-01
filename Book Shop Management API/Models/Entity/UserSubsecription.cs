namespace Book_Shop_Management_API.Models.Entity
{
    public class UserSubsecription
    {
        public int Id { get; set; }
        public DateTime SubsecriptionDate { get; set; }
        public string SerialNumberSubsecription { get; set; }
        public virtual User User { get; set; }
        public virtual Subsecription Subsecription {get; set; } 
    }
}
