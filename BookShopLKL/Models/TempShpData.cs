﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShopLKL.Models
{
    public class TempShpData
    {
        public static int UserID { get; set; }
        public static List<OrderDetail> items { get; set; }
    }
}