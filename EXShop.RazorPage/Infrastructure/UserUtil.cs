﻿using System.Security.Claims;
namespace EXShop.RazorPage.Infrastructure;
public static class UserUtil
{
    public static long GetUserId(this ClaimsPrincipal principal)
    {
        if (principal == null)
            throw new ArgumentNullException(nameof(principal));

        return Convert.ToInt64(principal.FindFirst(ClaimTypes.NameIdentifier)?.Value);
    }
}