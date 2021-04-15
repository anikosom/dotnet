using System.Threading.Tasks;
using ToDoWebApplication.DataAccess.Contracts;
using ToDoWebApplication.BLL.Contracts;
using ToDoWebApplication.Domain.Models;

namespace ToDoWebApplication.BLL.Implementations
{
    public class TaskUpdateService : ITaskUpdateService
    {
        private ITaskDataAccess TaskDataAccess { get; }
        private ICategoryGetService CategoryGetService { get; }

        public TaskUpdateService(ITaskDataAccess taskDataAccess, ICategoryGetService categoryGetService)
        {
            this.TaskDataAccess = taskDataAccess;
            this.CategoryGetService = categoryGetService;
        }

        public async Task<Domain.Task> UpdateAsync(TaskUpdateModel task)
        {
            await this.CategoryGetService.ValidateAsync(task);

            return await this.TaskDataAccess.UpdateAsync(task);
        }
    }
}
