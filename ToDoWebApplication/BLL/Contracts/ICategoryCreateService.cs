using System.Threading.Tasks;
using ToDoWebApplication.Domain.Models;
using ToDoWebApplication.Domain;

namespace ToDoWebApplication.BLL.Contracts
{
    public interface ICategoryCreateService
    {  
        Task<Category> CreateAsync(CategoryUpdateModel category);
    }
}
