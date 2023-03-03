using Microsoft.AspNetCore.Identity;

namespace HotelListing.Database
{
    public class ApiUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
