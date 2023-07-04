using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAsseccLayer.Repostory.Interfase
{
    public interface IRepostory<T>
    {
        List<T> GetAll();

        void Insert(T p);
        
        T Get(Expression<Func<T, bool>> filter);
        
        void Update(T p);
        
        void Delete(T p);
        
        List<T> List(Expression<Func<T, bool>> filter);
    }
}
