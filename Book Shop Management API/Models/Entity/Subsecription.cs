using static Book_Shop_Management_API.Models.Entity.User;

namespace Book_Shop_Management_API.Models.Entity
{
    public class Subsecription
    {
        public int SubsecriptionId { get; set; }
        public string SubsecriptionType { get; set; }
        public string SubsecriptionName { get; set; }
        public string Description { get; set; }
        public string DurationDay { get; set; }
        public string DownloadBookAmount { get; set; }
        public float Price { get; set; }
        public bool IsAvaible { get; set; }
        public int? ClientId { get; set; }
        public int? EmployeeId { get; set; }
        public int? AdminId { get; set; }
        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Admin Admin { get; set; }
        public virtual List<UserSubsecription> UserSubsecriptions { get; set; }
    }
}