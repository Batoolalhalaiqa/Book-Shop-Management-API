namespace Book_Shop_Management_API.DTOs.Authantication
{
    public class RestPasswordDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
