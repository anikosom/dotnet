using System.Threading.Tasks;
using ToDoWebApplication.Domain.Models;

namespace ToDoWebApplication.BLL.Contracts
{
    public interface ITaskCreateService
    {
        Task<Domain.Task> CreateAsync(TaskUpdateModel task);
    }
}
