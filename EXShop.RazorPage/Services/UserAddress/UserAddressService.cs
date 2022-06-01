using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.UserAddress;
using EXShop.RazorPage.Models.UserAddresses;

namespace EXShop.RazorPage.Services.UserAddress;

public class UserAddressService : IUserAddressService
{
    private readonly HttpClient _Client;

    public UserAddressService(HttpClient client)
    {
        _Client = client;
    }

    public async Task<ApiResult?> AddAddress(AddUserAddressCommand command)
    {
        var res = await _Client.PostAsJsonAsync("UserAddress", command);
        return await res.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult?> DeleteAddress(long addressId)
    {
        var res = await _Client.DeleteAsync("UserAddress");
        return await res.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult?> EditAddress(EditUserAddressCommand command)
    {
        var res = await _Client.PutAsJsonAsync("UserAddress", command);
        return await res.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<AddressDTO?> GetAddressById(long userAddressId)
    {
        var res = await _Client.GetFromJsonAsync<ApiResult<AddressDTO>>($"UserAddress/{userAddressId}");
        return res?.Data;
    }

    public async Task<List<AddressDTO>?> GetAddressesList()
    {
        var res = await _Client.GetFromJsonAsync<ApiResult<List<AddressDTO>>>($"UserAddress");
        return res?.Data;
    }
}