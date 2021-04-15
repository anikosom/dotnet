using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoWebApplication.DataAccess.Entities
{
    public partial class Task
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
