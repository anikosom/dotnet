using System.Threading.Tasks;
using ToDoWebApplication.Domain.Contracts;

namespace ToDoWebApplication.BLL.Contracts
{
    public interface ITaskRemoveService
    {
        Task<Domain.Task> RemoveAsync(ITaskIdentity task);
    }
}
