﻿using System;
using System.Collections.Generic;

namespace LibraryApp.API.Data
{
    public partial class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int? AuthorId { get; set; }
        public string? Isbn { get; set; }
        public string? Summary { get; set; }
        public string? Image { get; set; }

        public virtual Author? Author { get; set; }
    }
}
