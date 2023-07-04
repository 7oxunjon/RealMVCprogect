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
    public class HeadingRepostory : IHeadingDl
    {
        AppDbContext context = new AppDbContext();
        DbSet<Heading>? _heading;

        public void Delete(Heading p)
        {
            _heading?.Remove(p);
            context.SaveChanges();
        }

        public Heading Get(Expression<Func<Heading, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Heading> GetAll()
        {

           return _heading.ToList();
            context.SaveChanges();
        }

        public void Insert(Heading p)
        {
             _heading.Add(p);
            context.SaveChanges();
        }

        public List<Heading> List(Expression<Func<Heading, bool>> filter)
        {
            return _heading.Where(filter).ToList();
        }

        public void Update(Heading p)
        {
            context.SaveChanges();
        }
    }
}
