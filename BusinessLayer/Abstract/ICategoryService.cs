using EntityLayer.Concreat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();

        Category GetById(int id);

        void CategoryAddBL(Category category);

        void CategoryDeleteBL(Category category);

        void CategoryUpdateBL(Category category);

    }
}
