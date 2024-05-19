using System;
using System.Collections.Generic;

namespace DanhGiaRenLuyen_V6.Models.DBModel;

public partial class GroupQuestion
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<QuestionList> QuestionLists { get; set; } = new List<QuestionList>();
}
