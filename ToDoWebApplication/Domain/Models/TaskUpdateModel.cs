using System;
using ToDoWebApplication.Domain.Contracts;

namespace ToDoWebApplication.Domain.Models
{
    public class TaskUpdateModel : ITaskIdentity, ICategoryContainer
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public bool IsDone { get; set; }

        public int? CategoryId { get; set; }
    }
}
