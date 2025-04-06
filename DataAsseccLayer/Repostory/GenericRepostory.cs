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


namespace DataAsseccLayer.Repostory
{
    public class GenericRepostory<T> : IRepostory<T> where T : class
    {
        AppDbContext dbContext = new AppDbContext();
        DbSet<T> _object;
        public GenericRepostory()
        {
            _object = dbContext.Set<T>();
        }

        public void Delete(T p)
        {
            var deleteEntity = dbContext.Entry(p);
            deleteEntity.State = EntityState.Deleted;
           // _object.Remove(p);
            dbContext.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _object.ToList();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {

            return _object.SingleOrDefault(filter);
        }

        public void Insert(T p)
        {
            var addeEntity = dbContext.Entry(p);
            addeEntity.State = EntityState.Added;
            //_object.Add(p);
            dbContext.SaveChanges();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            try
            {
                var updateEntity = dbContext.Entry(p);
                updateEntity.State = EntityState.Modified;
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
            
        }

        
    }
}
