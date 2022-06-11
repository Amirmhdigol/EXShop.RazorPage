using AutoMapper;
using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.UserAddress;
using EXShop.RazorPage.Models.UserAddresses;
using EXShop.RazorPage.Services.UserAddress;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EXShop.RazorPage.Pages.Profile.Addresses;
public class IndexModel : BaseRazorPage
{
    private readonly IUserAddressService _userAddressService;
    private readonly IRenderViewToString _renderViewToString;
    private readonly IMapper _mapper;

    public IndexModel(IUserAddressService userAddressService, IRenderViewToString renderViewToString, IMapper mapper)
    {
        _userAddressService = userAddressService;
        _renderViewToString = renderViewToString;
        _mapper = mapper;
    }

    public List<AddressDTO> Addresses { get; set; }
    public async Task OnGet()
    {
        var result = await _userAddressService.GetAddressesList();
        Addresses = result;
    }

    public async Task<IActionResult> OnPostAsync(long addressId)
    {
        var res = await _userAddressService.DeleteAddress(addressId);
        return RedirectAndShowAlert(res, RedirectToPage("Index"), RedirectToPage("Index"));
    }
    public async Task<IActionResult> OnPostAddAddress(AddUserAddressViewModel viewModel)
    {
        return await AjaxTryCatch(async () =>
        {
            var model = _mapper.Map<AddUserAddressCommand>(viewModel);
            var res = await _userAddressService.AddAddress(model);
            return res;
        });
    }

    public async Task<IActionResult> OnGetShowAddPage()
    {
        return await AjaxTryCatch(async () =>
        {
            var view = await _renderViewToString.RenderToStringAsync("_Add", new AddUserAddressViewModel(), PageContext);
            return ApiResult<string>.Success(view);
        }, true);
    }
    public async Task<IActionResult> OnGetShowEditPage(long addressId)
    {
        return await AjaxTryCatch(async () =>
        {
            var address = await _userAddressService.GetAddressById(addressId);
            var model = _mapper.Map<EditUserAddressViewModel>(address);
            var view = await _renderViewToString.RenderToStringAsync("_Edit", model, PageContext);
            return ApiResult<string>.Success(view);
        }, true);
    }
}