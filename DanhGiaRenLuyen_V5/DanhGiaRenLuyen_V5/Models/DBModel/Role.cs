﻿using System;
using System.Collections.Generic;

namespace DanhGiaRenLuyen_V5.Models.DBModel;

public partial class Role
{
    public int Id { get; set; }

    public string? RoleName { get; set; }

    public byte? IsActive { get; set; }

    public virtual ICollection<AccountAdmin> AccountAdmins { get; set; } = new List<AccountAdmin>();
}
