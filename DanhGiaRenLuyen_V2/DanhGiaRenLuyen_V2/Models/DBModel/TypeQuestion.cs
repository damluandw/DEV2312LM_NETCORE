using System;
using System.Collections.Generic;

namespace DanhGiaRenLuyen_V2.Models.DBModel;

public partial class TypeQuestion
{
    public int Id { get; set; }

    public string? TypeQuestion1 { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
