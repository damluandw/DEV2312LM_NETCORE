using System;
using System.Collections.Generic;

namespace DanhGiaRenLuyen.Models.DBModel;

public partial class AccountStudent
{
    public string Id { get; set; } = null!;

    public string? Username { get; set; }

    public string? Password { get; set; }

    public DateTime? Createdate { get; set; }

    public DateTime? Updatedate { get; set; }

    public byte? Isactive { get; set; }
}
