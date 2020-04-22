using System.Collections.Generic;
using System.Linq;
using CGIBack.Data;
using CGIBack.Models;

namespace CGIBack.Repositories
{
    public interface ICategoryRepository
    {
        List<string> GetCategoryNamesById(List<int> ids);
    }

    public class CategoryRepository : ICategoryRepository
    {
        readonly List<Category> Categories = new CategoryList().categories;

        public List<string> GetCategoryNamesById(List<int> ids)
        {
            List<string> CategoryNames = new List<string>();
            foreach (int n in ids)
            {
                CategoryNames.Add(Categories.Where(s => s.Id.Equals(n)).FirstOrDefault().Name);
            }
            return CategoryNames;
        }
    }
}
