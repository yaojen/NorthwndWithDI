using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwnd.Models.Interface
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetByID(int productID);

        IEnumerable<Product> GetByCateogy(int categoryID);
    }
}
