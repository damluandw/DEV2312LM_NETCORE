﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson08
{
    internal class Film
    {
        public string FilmID { get; set; }
        public string FilmName { get; set; }
        public float FilmPrice { get; set; }
        public Film() { }
        public Film(string filmID, string filmName, float filmPrice)
        {
            FilmID = filmID;
            FilmName = filmName;
            FilmPrice = filmPrice;
        }

    }
}