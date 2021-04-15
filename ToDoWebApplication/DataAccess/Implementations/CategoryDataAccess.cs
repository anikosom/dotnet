using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using ToDoWebApplication.DataAccess.Context;
using ToDoWebApplication.DataAccess.Contracts;
using ToDoWebApplication.Domain;
using ToDoWebApplication.Domain.Models;
using ToDoWebApplication.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ToDoWebApplication.DataAccess.Implementations
{
    public class CategoryDataAccess : ICategoryDataAccess
    {
        private ToDoWebApplicationContext Context { get; }
        private IMapper Mapper { get; }

        public CategoryDataAccess(ToDoWebApplicationContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<Category> GetAsync(ICategoryIdentity categoryId)
        {
            return Mapper.Map<Category>(await Get(categoryId));
        }

        private async Task<Entities.Category> Get(ICategoryIdentity categoryId)
        {
            if (categoryId == null)
            {
                throw new ArgumentNullException(nameof(categoryId));
            }

            return await Context.Category
                .FirstOrDefaultAsync(m => m.Id == categoryId.Id);
        }

        public async Task<IEnumerable<Category>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Category>>(
                await this.Context.Category.ToListAsync());
        }

        public async Task<Category> InsertAsync(CategoryUpdateModel Category)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Category>(Category));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Category>(result.Entity);
        }
    }
}