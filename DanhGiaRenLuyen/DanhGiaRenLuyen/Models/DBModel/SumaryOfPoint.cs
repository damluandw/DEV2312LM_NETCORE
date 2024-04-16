using System;
using System.Collections.Generic;

namespace DanhGiaRenLuyen.Models.DBModel;

public partial class Sumaryofpoint
{
    public int Id { get; set; }

    public string? Studentid { get; set; }

    public int? Semesterid { get; set; }

    public int? Selfpoint { get; set; }

    public int? Classpoint { get; set; }

    public int? Lecturerpoint { get; set; }

    public string? Classify { get; set; }

    public string? Createby { get; set; }

    public string? Updateby { get; set; }

    public DateTime? Updatedate { get; set; }

    public virtual Semester? Semester { get; set; }

    public virtual Student? Student { get; set; }
}
