using System;
using System.Collections.Generic;

namespace LibraryApp.API.Data
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string? FirsrName { get; set; }
        public string? LastName { get; set; }
        public string? Biography { get; set; }
        public string? Image { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
