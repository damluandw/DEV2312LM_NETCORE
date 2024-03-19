using System;
using System.Collections.Generic;

namespace NETCore_Lesson07_LabTuLam.Models;

public partial class Blog
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public byte? Status { get; set; }

    public DateTime? Createdate { get; set; }

    public string? Image { get; set; }

    public string? Description { get; set; }
}
