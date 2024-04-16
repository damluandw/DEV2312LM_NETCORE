using System;
using System.Collections.Generic;

namespace DanhGiaRenLuyen.Models.DBModel;

public partial class Classify
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Pointmin { get; set; }

    public int? Pointmax { get; set; }

    public int? Orderby { get; set; }
}
