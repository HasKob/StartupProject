using HotelListing.DTOs;

namespace HotelListing.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(ApiUserLoginDto apiUserLoginDto);
        Task<string> CreateToken();
    }
}
