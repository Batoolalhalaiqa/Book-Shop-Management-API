namespace Book_Shop_Management_API.DTOs
{
    public class SubsecriptionDTO
    {
        public int SubsecriptionId { get; set; }
        public string SubsecriptionType { get; set; }
        public string SubsecriptionName { get; set; }
        public string Description { get; set; }
        public string DurationDay { get; set; }
        public string DownloadBookAmount { get; set; }
        public float Price { get; set; }
        public bool IsAvaible { get; set; } 
    }
}
