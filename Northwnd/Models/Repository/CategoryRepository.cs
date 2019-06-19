using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Northwnd.Models.Interface;


namespace Northwnd.Models.Repository
{
    public class CategoryRepository : ICategoryRepository, IDisposable
    {
        protected NORTHWNDEntities db
        {
            get;
            private set;
        }

        public CategoryRepository()
        {
            this.db = new NORTHWNDEntities();
        }

        public void Create(Category instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Categories.Add(instance);
                this.SaveChanges();
            }
        }

        public void Delete(Category instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Entry(instance).State = EntityState.Deleted;
                this.SaveChanges();
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.db != null)
                {
                    this.db.Dispose();
                    this.db = null;
                }
            }
        }

        public Category Get(int categoryID)
        {
            return db.Categories.FirstOrDefault(x => x.CategoryID == categoryID);
        }

        public IQueryable<Category> GetAll()
        {
            return db.Categories.OrderBy(x => x.CategoryID);
        }

        public void SaveChanges()
        {
            this.db.SaveChanges();
        }

        public void Update(Category instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Entry(instance).State = EntityState.Modified;
                this.SaveChanges();
            }
        }
    }
}