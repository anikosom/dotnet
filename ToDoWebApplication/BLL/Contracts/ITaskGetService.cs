using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoWebApplication.Domain.Contracts;

namespace ToDoWebApplication.BLL.Contracts
{
    public interface ITaskGetService
    {
        Task<IEnumerable<Domain.Task>> GetAsync();
        Task<Domain.Task> GetAsync(ITaskIdentity task);
    }
}
