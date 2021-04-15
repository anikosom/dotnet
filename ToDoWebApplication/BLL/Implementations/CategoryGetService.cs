using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using ToDoWebApplication.DataAccess.Contracts;
using ToDoWebApplication.BLL.Contracts;
using ToDoWebApplication.Domain.Contracts;
using Category = ToDoWebApplication.Domain.Category;

namespace ToDoWebApplication.BLL.Implementations
{
    public class CategoryGetService : ICategoryGetService
    {
        private ICategoryDataAccess CategoryDataAccess { get; }

        public CategoryGetService(ICategoryDataAccess сategoryDataAccess)
        {
            this.CategoryDataAccess = сategoryDataAccess;
        }

        public Task<IEnumerable<Category>> GetAsync()
        {
            return this.CategoryDataAccess.GetAsync();
        }

        public async Task ValidateAsync(ICategoryContainer сategoryContainer)
        {
            if (сategoryContainer == null)
            {
                throw new ArgumentNullException(nameof(сategoryContainer));
            }

            var Category = await this.GetAsync();

            if (сategoryContainer.CategoryId.HasValue && Category == null)
            {
                throw new InvalidOperationException($"Category not found by id {сategoryContainer.CategoryId}");
            }
        }

        public async Task<Category> GetAsync(ICategoryIdentity categoryId)
        {
            return await this.CategoryDataAccess.GetAsync(categoryId);
        }
    }
}