using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.Users;

namespace EXShop.RazorPage.Services.Users;

public class UserService : IUserService
{
    private readonly HttpClient _client;

    public UserService(HttpClient client)
    {
        _client = client;
    }

    //public async Task<ApiResult> AddToken(AddUserTokenCommand command)
    //{
    //}

    public async Task<ApiResult?> EditCurrentUser(EditUserCommand command)
    {
        var formData = new MultipartFormDataContent();
        formData.Add(new StringContent(command.PhoneNumber), "PhoneNumber");

        if (command.Avatar != null)
            formData.Add(new StreamContent(command.Avatar.OpenReadStream()), "Avatar", command.Avatar.FileName);

        formData.Add(new StringContent(command.Gender.ToString()), "Gender");
        formData.Add(new StringContent(command.Name), "Name");
        formData.Add(new StringContent(command.Family), "Family");
        formData.Add(new StringContent(command.Email), "Email");

        var result = await _client.PutAsync("User/current", formData);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult?> ChangeUserPassword(ChangePasswordCommand command)
    {
        var res = await _client.PutAsJsonAsync("User/ChangePassword", command); 
        return await res.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult?> CreateUser(CreateUserCommand command)
    {
        var res = await _client.PostAsJsonAsync("User", command);
        return await res.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult?> EditUser(EditUserCommand command)
    {
        var formData = new MultipartFormDataContent();
        formData.Add(new StringContent(command.PhoneNumber), "PhoneNumber");
        formData.Add(new StreamContent(command.Avatar.OpenReadStream()), "Avatar", command.Avatar.FileName);
        formData.Add(new StringContent(command.Gender.ToString()), "Gender");
        formData.Add(new StringContent(command.Name), "Name");
        formData.Add(new StringContent(command.Family), "Family");
        formData.Add(new StringContent(command.Email), "Email");

        var result = await _client.PutAsync($"User", formData);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    //public Task<UserTokenDTO?> GetTokenByJwtToken(string jwtToken)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<UserTokenDTO?> GetTokenByRefreshToken(string refreshToken)
    //{
    //    throw new NotImplementedException();
    //}

    public async Task<UserFilterResult?> GetUserByFilter(UserFilterParams filterParams)
    {
        var res = await _client.GetFromJsonAsync<ApiResult<UserFilterResult>>($"User?filterParams={filterParams}");
        return res?.Data;
    }

    public async Task<UserDTO?> GetCurrentUser()
    {
        var result = await _client.GetFromJsonAsync<ApiResult<UserDTO?>>("User/current");
        return result.Data;
    }

    public async Task<UserDTO?> GetUserById(long userId)
    {
        var res = await _client.GetFromJsonAsync<ApiResult<UserDTO>>($"User/{userId}");
        return res?.Data;
    }

    public async Task<UserDTO?> GetUserByPhoneNumber(string phoneNumber)
    {
        var res = await _client.GetFromJsonAsync<ApiResult<UserDTO>>($"User/{phoneNumber}");
        return res?.Data;
    }

    //public Task<ApiResult> RemoveToken(RemoveUserTokenCommand command)
    //{
    //    throw new NotImplementedException();
    //}
}