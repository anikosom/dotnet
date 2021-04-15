using System.Threading.Tasks;
using System.Collections.Generic;
using ToDoWebApplication.Domain;
using ToDoWebApplication.Domain.Models;
using ToDoWebApplication.Domain.Contracts;

namespace ToDoWebApplication.DataAccess.Contracts
{
    public interface ICategoryDataAccess
    {
        Task<Category> GetAsync(ICategoryIdentity categoryId);
        Task<Category> InsertAsync(CategoryUpdateModel category);
        Task<IEnumerable<Category>> GetAsync();
    }
}
