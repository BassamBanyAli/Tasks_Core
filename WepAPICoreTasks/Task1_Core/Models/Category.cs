﻿using System;
using System.Collections.Generic;

namespace Task1_Core.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? CategoryImage { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
