using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwnd.Models.Interface
{
    public interface ICategoryRepository
    {
        void Create(Category instance);

        void Update(Category instance);

        void Delete(Category instance);

        Category Get(int categoryID);

        IQueryable<Category> GetAll();

        void SaveChanges();
    }
}
