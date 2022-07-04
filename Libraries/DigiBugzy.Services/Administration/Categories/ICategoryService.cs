
global using DigiBugzy.Core.Domain.Administration.Categories;

namespace DigiBugzy.Services.Administration.Categories
{
    public interface ICategoryService
    {
        public Category GetById(int id);

        public List<Category> Get(StandardFilter filter);

        public void Delete(int id, bool hardDelete = false);

        public void Update(Category entity);

        public void Create(Category entity);
    }
}
