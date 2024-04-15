using System;
using System.Collections.Generic;

namespace DanhGiaRenLuyen.Models.DBModel;

public partial class Department
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Lecturer> Lecturers { get; set; } = new List<Lecturer>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
