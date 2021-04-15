using System.Threading.Tasks;
using ToDoWebApplication.BLL.Contracts;
using ToDoWebApplication.DataAccess.Contracts;
using ToDoWebApplication.Domain.Contracts;

namespace ToDoWebApplication.BLL.Implementations
{
    public class TaskRemoveService : ITaskRemoveService
    {
        private ITaskDataAccess TaskDataAccess { get; }

        public TaskRemoveService(ITaskDataAccess taskDataAccess)
        {
            TaskDataAccess = taskDataAccess;
        }

        public async Task<Domain.Task> RemoveAsync(ITaskIdentity taskId)
        {
            return await TaskDataAccess.RemoveAsync(taskId);
        }
    }
}
