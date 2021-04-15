using System;
using System.ComponentModel.DataAnnotations;
using ToDoWebApplication.Domain.Contracts;

namespace ToDoWebApplication.Domain
{
    public class Task : ICategoryContainer
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Title must contain at least two characters!")]
        [MaxLength(200, ErrorMessage = "Title must contain a maximum of 200 characters!")]
        public string Title { get; set; }

        public bool IsDone { get; set; }

        public Category Category { get; set; }

        int? ICategoryContainer.CategoryId => this.Category.Id;
    }
}
