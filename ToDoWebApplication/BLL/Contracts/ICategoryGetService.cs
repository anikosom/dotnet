using System.Threading.Tasks;
using System.Collections.Generic;
using ToDoWebApplication.Domain.Contracts;
using Category = ToDoWebApplication.Domain.Category;

namespace ToDoWebApplication.BLL.Contracts
{
    public interface ICategoryGetService
    {
        Task ValidateAsync(ICategoryContainer categoryContainer);
        Task<Category> GetAsync(ICategoryIdentity categoryId);
        Task<IEnumerable<Category>> GetAsync();
    }
}
