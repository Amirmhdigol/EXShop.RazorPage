using AutoMapper;
using EXShop.RazorPage.Models.UserAddress;
using EXShop.RazorPage.Models.UserAddresses;

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