using System.Threading.Tasks;
using ToDoWebApplication.DataAccess.Contracts;
using ToDoWebApplication.BLL.Contracts;
using ToDoWebApplication.Domain.Models;

namespace ToDoWebApplication.BLL.Implementations
{
    public class TaskCreateService : ITaskCreateService
    {
        private ITaskDataAccess TaskDataAccess { get; }
        private ICategoryGetService CategoryGetService { get; }

        public TaskCreateService(ITaskDataAccess TaskDataAccess, ICategoryGetService CategoryGetService)
        {
            this.TaskDataAccess = TaskDataAccess;
            this.CategoryGetService = CategoryGetService;
        }

        public async Task<Domain.Task> CreateAsync(TaskUpdateModel task)
        {
            await this.CategoryGetService.ValidateAsync(task);

            return await this.TaskDataAccess.InsertAsync(task);
        }
    }
}