using System;
using System.Collections.Generic;

namespace DanhGiaRenLuyen.Models.DBModel;

public partial class Course
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public byte? Isactive { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
