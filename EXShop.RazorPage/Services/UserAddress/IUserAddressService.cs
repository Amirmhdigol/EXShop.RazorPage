using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.UserAddresses;

namespace EXShop.RazorPage.Services.UserAddress;
public interface IUserAddressService
{
    Task<ApiResult?> AddAddress(AddUserAddressCommand command);
    Task<ApiResult?> EditAddress(EditUserAddressCommand command);
    Task<ApiResult?> DeleteAddress(long addressId);
    Task<ApiResult?> SetActiveAddress(long addressId);

    Task<AddressDTO?> GetAddressById(long userAddressId);
    Task<List<AddressDTO>?> GetAddressesList();
}