using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoWebApplication.DataAccess.Contracts;
using ToDoWebApplication.BLL.Contracts;
using ToDoWebApplication.Domain.Contracts;

namespace ToDoWebApplication.BLL.Implementations
{
    public class TaskGetService : ITaskGetService
    {
        private ITaskDataAccess TaskDataAccess { get; }

        public TaskGetService(ITaskDataAccess taskDataAccess)
        {
            this.TaskDataAccess = taskDataAccess;
        }

        public Task<IEnumerable<Domain.Task>> GetAsync()
        {
            return this.TaskDataAccess.GetAsync();
        }

        public Task<Domain.Task> GetAsync(ITaskIdentity task)
        {
            return this.TaskDataAccess.GetAsync(task);
        }
    }
}