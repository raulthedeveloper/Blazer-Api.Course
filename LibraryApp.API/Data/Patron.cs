using System;
using System.Collections.Generic;

namespace LibraryApp.API.Data
{
    public partial class Patron
    {
        public Patron()
        {
            BookRentals = new HashSet<BookRental>();
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public virtual ICollection<BookRental> BookRentals { get; set; }
    }
}
