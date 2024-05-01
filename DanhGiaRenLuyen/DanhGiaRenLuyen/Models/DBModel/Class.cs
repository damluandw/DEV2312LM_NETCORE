﻿using System;
using System.Collections.Generic;

namespace DanhGiaRenLuyen.Models.DBModel;

public partial class Class
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? CourseId { get; set; }

    public int? DepartmentId { get; set; }

    public byte? Isactive { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}