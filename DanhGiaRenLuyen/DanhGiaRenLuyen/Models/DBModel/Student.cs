using System;
using System.Collections.Generic;

namespace DanhGiaRenLuyen.Models.DBModel;

public partial class Student
{
    public string Id { get; set; } = null!;

    public string? FullName { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? CourseId { get; set; }

    public int? DepartmentId { get; set; }

    public int? ClassId { get; set; }

    public string? PositionId { get; set; }

    public byte? Isactive { get; set; }

    public virtual Class? Class { get; set; }

    public virtual ICollection<ClassAnswer> ClassAnswers { get; set; } = new List<ClassAnswer>();

    public virtual Course? Course { get; set; }

    public virtual Department? Department { get; set; }

    public virtual Position? Position { get; set; }

    public virtual ICollection<SelfAnswer> SelfAnswers { get; set; } = new List<SelfAnswer>();

    public virtual ICollection<SumaryOfPoint> SumaryOfPoints { get; set; } = new List<SumaryOfPoint>();
}
