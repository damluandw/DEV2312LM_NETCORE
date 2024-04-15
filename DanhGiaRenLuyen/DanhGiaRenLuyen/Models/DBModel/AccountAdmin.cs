using System;
using System.Collections.Generic;

namespace DanhGiaRenLuyen.Models.DBModel;

public partial class AccountAdmin
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public DateTime? Createdate { get; set; }

    public DateTime? Updatedate { get; set; }

    public byte? Isactive { get; set; }

    public int? Roleid { get; set; }

    public virtual Role? Role { get; set; }
}
