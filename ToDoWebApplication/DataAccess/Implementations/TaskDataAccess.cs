using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ToDoWebApplication.DataAccess.Context;
using ToDoWebApplication.DataAccess.Contracts;
using ToDoWebApplication.Domain.Contracts;
using ToDoWebApplication.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ToDoWebApplication.DataAccess.Implementations
{
    public class TaskDataAccess : ITaskDataAccess
    {
        private ToDoWebApplicationContext Context { get; }
        private IMapper Mapper { get; }

        public TaskDataAccess(ToDoWebApplicationContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<Domain.Task> InsertAsync(TaskUpdateModel Task)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Domain.Task>(Task));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Domain.Task>(result.Entity);
        }

        public async Task<IEnumerable<Domain.Task>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Domain.Task>>(
                await this.Context.Task.Include(x => x.Category).ToListAsync());
        }

        public async Task<Domain.Task> GetAsync(ITaskIdentity Task)
        {
            var result = await this.Get(Task);

            return this.Mapper.Map<Domain.Task>(result);
        }

        private async Task<Entities.Task> Get(ITaskIdentity task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            return await Context.Task
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == task.Id);
        }

        public async Task<Domain.Task> UpdateAsync(TaskUpdateModel Task)
        {
            var existing = await this.Get(Task);

            var result = this.Mapper.Map(Task, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Domain.Task>(result);
        }

        public async Task<Domain.Task> RemoveAsync(ITaskIdentity pokemonId)
        {
            var result = await Get(pokemonId);

            Context.Remove(result);
            await Context.SaveChangesAsync();

            return Mapper.Map<Domain.Task>(result);
        }
    }
}