using CGIBack.Repositories;

namespace CGIBack.Services
{
    public interface ICategoryService : ICategoryRepository { }
    public class CategoryService : CategoryRepository, ICategoryService { }
}
