using System;
using System.Collections.Generic;

namespace DanhGiaRenLuyen_V5.Models.DBModel;

public partial class SelfAnswer
{
    public int Id { get; set; }

    public string? StudentId { get; set; }

    public int? AnswerId { get; set; }

    public int? SemesterId { get; set; }

    public virtual AnswerList? Answer { get; set; }

    public virtual Semester? Semester { get; set; }

    public virtual Students? Student { get; set; }
}
