using AutoMapper;
using EXShop.RazorPage.Models.UserAddresses;
using EXShop.RazorPage.ViewModels.Users.Addresses;

namespace EXShop.RazorPage.Infrastructure;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<AddUserAddressCommand, AddUserAddressViewModel>().ReverseMap();
        CreateMap<EditUserAddressCommand, EditUserAddressViewModel>().ReverseMap();
        CreateMap<AddressDTO, EditUserAddressViewModel>().ReverseMap();
    }
}