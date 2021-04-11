using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoWebApplication.Domain
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Title must contain at least two characters!")]
        [MaxLength(200, ErrorMessage = "Title must contain a maximum of 200 characters!")]
        public string Title { get; set; }

        public byte Priority { get; set; }
    }
}
