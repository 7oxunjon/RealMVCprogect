using DataAsseccLayer.Concreat;
using DataAsseccLayer.Repostory.Interfase;
using EntityLayer.Concreat;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAsseccLayer.Repostory
{
    public class CategoryRepostory : ICategoryDl
    {
        AppDbContext dbContext = new AppDbContext();
        DbSet<Category> _object;

        public void Delete(Category p)
        {
            _object?.Remove(p);
            dbContext.SaveChanges();
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public List<Category> GetAll()
        {
            return _object.ToList();
        }

        public void Insert(Category p)
        {
            _object?.Add(p);
            dbContext.SaveChanges();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(Category p)
        {
            dbContext.SaveChanges();
        }
    }
}
