using System;
using System.Collections.Generic;

namespace DanhGiaRenLuyen.Models.DBModel;

public partial class SumaryOfPoint
{
    public int Id { get; set; }

    public string? StudentId { get; set; }

    public int? SemesterId { get; set; }

    public int? SelfPoint { get; set; }

    public int? ClassPoint { get; set; }

    public int? LecturerPoint { get; set; }

    public string? Createby { get; set; }

    public string? Updateby { get; set; }

    public DateTime? Updatedate { get; set; }

    public virtual Semester? Semester { get; set; }

    public virtual Student? Student { get; set; }
}
