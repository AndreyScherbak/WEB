﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Book
    {
        public string Category { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Price { get; set; }
    }
}