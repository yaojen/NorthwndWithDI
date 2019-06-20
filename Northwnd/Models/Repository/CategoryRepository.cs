using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Northwnd.Models.Interface;

namespace Northwnd.Models.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        /// <summary>
        /// Gets the by ID.
        /// </summary>
        /// <param name="categoryID">The category ID.</param>
        /// <returns></returns>
        public Category GetById(int categoryID)
        {
            return this.Get(x => x.CategoryID == categoryID);
        }

    }
}