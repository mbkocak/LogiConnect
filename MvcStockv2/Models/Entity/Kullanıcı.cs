﻿using System;
using System.Collections.Generic;

namespace MvcStockv2.Models.Entity;

public partial class Kullanıcı
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }
}
