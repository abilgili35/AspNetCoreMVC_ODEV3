﻿using System;
using System.Collections.Generic;

namespace AspNetCoreMVC_ODEV3.Models;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
