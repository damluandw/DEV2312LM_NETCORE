using System;
using System.Collections.Generic;

namespace DanhGiaRenLuyen_V2.Models.DBModel;

public partial class Classify
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? PointMin { get; set; }

    public int? PointMax { get; set; }

    public int? OrderBy { get; set; }
}
