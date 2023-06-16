using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Books
{
    public class CreateUpdateBookDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public BookType Type { get; set; } = BookType.Undefined;

        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; } = DateTime.Now;

        public float Price { get; set; }
    }
}