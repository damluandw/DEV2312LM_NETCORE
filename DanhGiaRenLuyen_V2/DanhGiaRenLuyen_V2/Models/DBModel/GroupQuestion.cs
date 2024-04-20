using System;
using System.Collections.Generic;

namespace DanhGiaRenLuyen_V2.Models.DBModel;

public partial class GroupQuestion
{
    public int Id { get; set; }

    public string? GroupQuestion1 { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
