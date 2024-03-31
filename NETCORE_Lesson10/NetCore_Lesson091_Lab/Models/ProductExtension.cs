using System;
using System.Collections.Generic;

namespace NetCore_Lesson091_Lab.Models;

public partial class ProductExtension
{
    public int Id { get; set; }

    public int? Pid { get; set; }

    public int? Eid { get; set; }

    public string? Content { get; set; }
}
