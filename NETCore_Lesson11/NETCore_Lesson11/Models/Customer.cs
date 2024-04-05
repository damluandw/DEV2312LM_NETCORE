using System;
using System.Collections.Generic;

namespace NETCore_Lesson11.Models;

public partial class Customer
{
    public long? Id { get; set; }

    public string? Name { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Avatar { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public long? CreateBy { get; set; }

    public long? UpdateBy { get; set; }

    public byte? Isdelete { get; set; }

    public byte? Isactive { get; set; }
}
