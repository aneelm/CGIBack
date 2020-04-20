using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CGIBack.Repositories;

namespace CGIBack.Services
{
	public interface ICategoryService : ICategoryRepository { }
	public class CategoryService : CategoryRepository, ICategoryService { }
}
