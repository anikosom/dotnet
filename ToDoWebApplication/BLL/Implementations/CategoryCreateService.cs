using System.Threading.Tasks;
using ToDoWebApplication.DataAccess.Contracts;
using ToDoWebApplication.BLL.Contracts;
using ToDoWebApplication.Domain;
using ToDoWebApplication.Domain.Models;

namespace ToDoWebApplication.BLL.Implementations
{
    public class CategoryCreateService : ICategoryCreateService
    {
        private ICategoryDataAccess CategoryDataAccess { get; }

        public CategoryCreateService(ICategoryDataAccess categoryDataAccess)
        {
            this.CategoryDataAccess = categoryDataAccess;
        }

        public async Task<Category> CreateAsync(CategoryUpdateModel category)
        {
            return await this.CategoryDataAccess.InsertAsync(category);
        }
    }
}
