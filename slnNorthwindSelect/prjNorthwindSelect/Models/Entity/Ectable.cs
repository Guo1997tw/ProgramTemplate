﻿using System;
using System.Collections.Generic;

namespace prjNorthwindSelect.Models.Entity;

public partial class Ectable
{
    public int Id { get; set; }

    public string? EmployeesName { get; set; }

    public string? CustomersName { get; set; }
}
