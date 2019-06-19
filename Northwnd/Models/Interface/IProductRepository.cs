using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwnd.Models.Interface
{
    public interface IProductRepository
    {
        void Create(Product instance);

        void Update(Product instance);

        void Delete(Product instance);

        Product Get(int productID);

        IQueryable<Product> GetAll();

        void SaveChanges();
    }
}
