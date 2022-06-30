using System;
using System.Collections.Generic;

namespace LibraryApp.API.Data
{
    public partial class BookRental
    {
        public int Id { get; set; }
        public int? PatronId { get; set; }
        public DateTime CheckOut { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsLate { get; set; }

        public virtual Patron? Patron { get; set; }
    }
}
