﻿using Microsoft.Ajax.Utilities;
using System.Web;
using System.Web.Mvc;

namespace AddressBook
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
