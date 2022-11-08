using System.ComponentModel.DataAnnotations;

namespace WEB_API.Models
{
    public class UserDetails
    {
        [Key]
        public int UserID { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? MobileNo { get; set; }
        public string? Address { get; set; }



    }
}
