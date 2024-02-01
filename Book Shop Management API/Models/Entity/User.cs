namespace Book_Shop_Management_API.Models.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public String FirstName { get; set; }
        public String lastName { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public String Password { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Specilization { get; set; }
        public virtual UserType UserType { get; set; }

        public class Admin : User
        {
            public virtual List<Subsecription> Subsecriptions { get; set; }

        }
        public class Client : User
        {
            public virtual List<Subsecription> Subsecriptions { get; set; }

        }
        public class Employee : User
        {
            public virtual List<Subsecription> Subsecriptions { get; set; }

        }
    }
}
