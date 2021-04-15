using System.Threading.Tasks;
using System.Collections.Generic;
using ToDoWebApplication.Domain.Models;
using ToDoWebApplication.Domain.Contracts;

namespace ToDoWebApplication.DataAccess.Contracts
{
    public interface ITaskDataAccess
    {
        Task<Domain.Task> InsertAsync(TaskUpdateModel Task);
        Task<IEnumerable<Domain.Task>> GetAsync();
        Task<Domain.Task> GetAsync(ITaskIdentity TaskId);
        Task<Domain.Task> UpdateAsync(TaskUpdateModel Task);
        Task<Domain.Task> RemoveAsync(ITaskIdentity taskId);
    }
}
