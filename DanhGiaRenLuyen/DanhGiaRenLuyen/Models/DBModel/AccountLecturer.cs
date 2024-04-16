using System;
using System.Collections.Generic;

namespace DanhGiaRenLuyen.Models.DBModel;

public partial class Accountlecturer
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Createby { get; set; }

    public DateTime? Createdate { get; set; }

    public DateTime? Updatedate { get; set; }

    public byte? Isactive { get; set; }

    public string? Lecturerid { get; set; }

    public virtual Lecturer? Lecturer { get; set; }
}
