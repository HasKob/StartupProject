using System.ComponentModel.DataAnnotations;

namespace HotelListing.Core.DTOs
{
    public class ApiUserLoginDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Your Password is limited to {2} to {1} characters", MinimumLength = 10)]
        public string Password { get; set; }

    }
    public class ApiUserDto : ApiUserLoginDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public ICollection<string> Roles { get; set; }

    }
}
