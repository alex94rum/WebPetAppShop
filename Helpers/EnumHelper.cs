﻿using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using System.Reflection;

namespace WebPetAppShop.Helpers
{
    public class EnumHelper
    {
        public static string? GetDisplayName(Enum enumValue)
        {
            return enumValue.GetType()
                    ?.GetMember(enumValue.ToString())
                    ?.First()
                    ?.GetCustomAttribute<DisplayAttribute>()
                    ?.GetName();
        }
    }
}
