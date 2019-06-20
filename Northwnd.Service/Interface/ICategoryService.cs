﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwnd.Models;
using Northwnd.Service.Misc;

namespace Northwnd.Service.Interface
{
    public interface ICategoryService
    {
        IResult Create(Category instance);

        IResult Update(Category instance);

        IResult Delete(int categoryID);

        bool IsExists(int categoryID);

        Category GetByID(int categoryID);

        IEnumerable<Category> GetAll();
    }
}
