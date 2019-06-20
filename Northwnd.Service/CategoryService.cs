﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwnd.Service.Interface;
using Northwnd.Service.Misc;
using Northwnd.Models;
using Northwnd.Models.Interface;
using Northwnd.Models.Repository;


namespace Northwnd.Service
{
    public class CategoryService : ICategoryService
    {
        private IRepository<Category> repository = new GenericRepository<Category>();


        public IResult Create(Category instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            IResult result = new Result(false);
            try
            {
                this.repository.Create(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IResult Update(Category instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            IResult result = new Result(false);
            try
            {
                this.repository.Update(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IResult Delete(int categoryID)
        {
            IResult result = new Result(false);

            if (!this.IsExists(categoryID))
            {
                result.Message = "找不到資料";
            }

            try
            {
                var instance = this.GetByID(categoryID);
                this.repository.Delete(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public bool IsExists(int categoryID)
        {
            return this.repository.GetAll().Any(x => x.CategoryID == categoryID);
        }

        public Category GetByID(int categoryID)
        {
            return this.repository.Get(x => x.CategoryID == categoryID);
        }

        public IEnumerable<Category> GetAll()
        {
            return this.repository.GetAll();
        }
    }
}
