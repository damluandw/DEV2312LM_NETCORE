using System;
using System.Collections.Generic;

namespace DanhGiaRenLuyen_V2.Models.DBModel;

public partial class Course
{
    public string Id { get; set; } = null!;

    public string? Course1 { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
