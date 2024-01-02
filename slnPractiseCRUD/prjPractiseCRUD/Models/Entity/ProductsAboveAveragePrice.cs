using System;
using System.Collections.Generic;

namespace prjPractiseCRUD.Models.Entity;

public partial class ProductsAboveAveragePrice
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}
