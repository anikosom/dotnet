using System;
using ToDoWebApplication.Domain.Contracts;

namespace ToDoWebApplication.Domain.Models
{
    public class CategoryUpdateModel : ICategoryIdentity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public byte Priority { get; set; }
    }
}
