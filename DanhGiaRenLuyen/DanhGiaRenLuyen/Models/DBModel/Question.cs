﻿using System;
using System.Collections.Generic;

namespace DanhGiaRenLuyen.Models.DBModel;

public partial class Question
{
    public int Id { get; set; }

    public string? Question1 { get; set; }

    public int? TypeQuestionId { get; set; }

    public int? SemesterId { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual Semester? Semester { get; set; }

    public virtual TypeQuestion? TypeQuestion { get; set; }
}