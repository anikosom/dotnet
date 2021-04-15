using System.Threading.Tasks;
using ToDoWebApplication.Domain.Models;

namespace ToDoWebApplication.BLL.Contracts
{
    public interface ITaskUpdateService
    {
        Task<Domain.Task> UpdateAsync(TaskUpdateModel task);
    }
}
