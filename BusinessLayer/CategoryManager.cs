using BusinessLayer.Abstract;
using DataAsseccLayer.Repostory.Interfase;
using EntityLayer.Concreat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDl _repo;

        public CategoryManager(ICategoryDl repo)
        {
            _repo = repo;
        }

        public void CategoryAddBL(Category category)
        {
            _repo.Insert(category);
        }

        public void CategoryDeleteBL(Category category)
        {
            _repo.Delete(category);
        }

        public void CategoryUpdateBL(Category category)
        {
            _repo.Update(category);
        }

        public Category GetById(int id)
        {

            return _repo.Get(x => x.CotegoryId==id);
        }

        public List<Category> GetList()
        {
           return _repo.GetAll();
        }


    }
}
