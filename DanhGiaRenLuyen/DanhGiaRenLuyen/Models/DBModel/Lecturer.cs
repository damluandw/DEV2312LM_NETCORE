﻿using System;
using System.Collections.Generic;

namespace DanhGiaRenLuyen.Models.DBModel;

public partial class Lecturer
{
    public string Id { get; set; } = null!;

    public string? FullName { get; set; }

    public int? DepartmentId { get; set; }

    public string? PositionId { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public byte? Isactive { get; set; }

    public virtual ICollection<Accountlecturer> Accountlecturers { get; set; } = new List<Accountlecturer>();

    public virtual Department? Department { get; set; }

    public virtual Position? Position { get; set; }
}