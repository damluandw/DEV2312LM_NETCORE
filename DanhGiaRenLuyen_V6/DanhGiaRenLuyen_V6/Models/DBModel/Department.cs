using System;
using System.Collections.Generic;

namespace DanhGiaRenLuyen_V6.Models.DBModel;

public partial class Department
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Times { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Lecturers> Lecturers { get; set; } = new List<Lecturers>();
}
