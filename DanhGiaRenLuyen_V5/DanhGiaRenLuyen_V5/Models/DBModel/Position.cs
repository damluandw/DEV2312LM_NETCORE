using System;
using System.Collections.Generic;

namespace DanhGiaRenLuyen_V5.Models.DBModel;

public partial class Position
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public virtual ICollection<Lecturers> Lecturers { get; set; } = new List<Lecturers>();

    public virtual ICollection<Students> Students { get; set; } = new List<Students>();
}
