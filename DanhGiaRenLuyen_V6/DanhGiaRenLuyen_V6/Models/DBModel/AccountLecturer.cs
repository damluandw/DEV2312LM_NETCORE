﻿using System;
using System.Collections.Generic;

namespace DanhGiaRenLuyen_V6.Models.DBModel;

public partial class AccountLecturer
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? CreateBy { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public byte? IsActive { get; set; }

    public string? LecturerId { get; set; }

    public virtual Lecturers? Lecturer { get; set; }
}
