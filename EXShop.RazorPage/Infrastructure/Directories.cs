﻿namespace EXShop.RazorPage.Infrastructure;

public class Directories
{
    public const string ProductImages = "/images/products";
    public const string ProductGalleryImages = "/images/products/gallery";
    public const string BannerImages = "/images/banners";
    public const string SliderImages = "/images/sliders";
    public const string UserAvatars = "/images/users/avatars";

    public static string GetSliderImage(string imageName)
    {
        return $"{SiteSettings.ServerPath}{SliderImages}/{imageName}";
    }
}