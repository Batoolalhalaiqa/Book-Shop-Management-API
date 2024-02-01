using static Book_Shop_Management_API.Helper.Enum.Enum;

namespace Book_Shop_Management_API.Models.Entity
{
    public class UserType
    {
        

        public int UserTypeID { get; set; }
        public string Name { get; set; }
        public Usertype Usertype { get; set; }
        public virtual List<User> Users { get; set; }


    }
}
