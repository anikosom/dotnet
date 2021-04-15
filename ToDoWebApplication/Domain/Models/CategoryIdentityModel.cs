using ToDoWebApplication.Domain.Contracts;

namespace ToDoWebApplication.Domain.Models
{
    public class CategoryIdentityModel : ICategoryIdentity
    {
        public int Id { get; }

        public CategoryIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}
