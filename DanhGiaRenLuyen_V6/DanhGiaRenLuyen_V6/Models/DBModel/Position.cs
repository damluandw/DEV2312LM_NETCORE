using System;
using System.Collections.Generic;

namespace DanhGiaRenLuyen_V6.Models.DBModel;

public partial class Position
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public byte? Status { get; set; }

    public virtual ICollection<Lecturers> Lecturers { get; set; } = new List<Lecturers>();

    public virtual ICollection<Students> Students { get; set; } = new List<Students>();
}
