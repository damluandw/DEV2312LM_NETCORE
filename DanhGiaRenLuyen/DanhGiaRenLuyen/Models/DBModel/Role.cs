using System;
using System.Collections.Generic;

namespace DanhGiaRenLuyen.Models.DBModel;

public partial class Role
{
    public int Id { get; set; }

    public string? Rolename { get; set; }

    public byte? Isactive { get; set; }

    public virtual ICollection<Accountadmin> Accountadmins { get; set; } = new List<Accountadmin>();
}
