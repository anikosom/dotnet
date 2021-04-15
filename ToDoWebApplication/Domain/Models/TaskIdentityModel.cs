using ToDoWebApplication.Domain.Contracts;

namespace ToDoWebApplication.Domain.Models
{
    public class TaskIdentityModel : ITaskIdentity
    {
        public int Id { get; }

        public TaskIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}