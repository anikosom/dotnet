using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoWebApplication.DataAccess.Entities
{
    public partial class Category
    {
        public Category()
        {
            this.Task = new HashSet<Task>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public byte Priority { get; set; }

        public virtual ICollection<Task> Task { get; set; }
    }
}