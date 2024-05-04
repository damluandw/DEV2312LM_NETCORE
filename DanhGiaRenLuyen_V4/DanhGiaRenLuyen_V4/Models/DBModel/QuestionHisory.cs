using System;
using System.Collections.Generic;

namespace DanhGiaRenLuyen_V4.Models.DBModel;

public partial class QuestionHisory
{
    public int Id { get; set; }

    public int? QuestionId { get; set; }

    public int? SemesterId { get; set; }

    public int? OrderBy { get; set; }

    public string? CreateBy { get; set; }

    public DateTime? CreateDate { get; set; }

    public virtual QuestionList? Question { get; set; }

    public virtual Semester? Semester { get; set; }
}
