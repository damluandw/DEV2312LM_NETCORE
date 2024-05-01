﻿using System;
using System.Collections.Generic;

namespace DanhGiaRenLuyen.Models.DBModel;

public partial class ClassAnswer
{
    public int Id { get; set; }

    public string? StudentId { get; set; }

    public int? AnswerId { get; set; }

    public string? Createby { get; set; }

    public virtual Answer? Answer { get; set; }

    public virtual Student? Student { get; set; }
}