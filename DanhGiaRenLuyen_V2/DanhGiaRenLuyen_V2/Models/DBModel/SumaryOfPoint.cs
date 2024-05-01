﻿using System;
using System.Collections.Generic;

namespace DanhGiaRenLuyen_V2.Models.DBModel;

public partial class SumaryOfPoint
{
    public int Id { get; set; }

    public string? StudentId { get; set; }

    public int? SemesterId { get; set; }

    public int? SelfPoint { get; set; }

    public int? ClassPoint { get; set; }

    public int? LecturerPoint { get; set; }

    public string? Classify { get; set; }

    public string? UserClass { get; set; }

    public string? UserLecturer { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Semester? Semester { get; set; }

    public virtual Student? Student { get; set; }
}
