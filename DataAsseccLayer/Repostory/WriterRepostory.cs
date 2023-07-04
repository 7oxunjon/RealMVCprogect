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
    public class WriterRepostory : IWriterDl
    {
        AppDbContext dbContext = new AppDbContext();
        DbSet<Writer> _obgect;

        public void Delete(Writer p)
        {
            _obgect?.Remove(p);
            dbContext.SaveChanges();
        }

        public Writer Get(Expression<Func<Writer, bool>> filter)
        {
            return _obgect.SingleOrDefault(filter);

        }

        public List<Writer> GetAll()
        {
            return _obgect.ToList();
        }

        public void Insert(Writer p)
        {
            _obgect?.Add(p);
            dbContext.SaveChanges();
        }

        public List<Writer> List(Expression<Func<Writer, bool>> filter)
        {
            return _obgect.Where(filter).ToList();
        }

        public void Update(Writer p)
        {
             dbContext.SaveChanges();
        }
    }
}
