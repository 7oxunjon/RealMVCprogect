using BusinessLayer.Abstract;
using DataAsseccLayer.Repostory.Interfase;
using EntityLayer.Concreat;
using Npgsql.Internal.TypeMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Maneger
{
    public class NewsManager : INewsService
    {
        INewsDL _newsdl;
        public NewsManager(INewsDL newsdl)
        {
            _newsdl = newsdl;
        }

        public News GetById(int id)
        {
            return _newsdl.Get(x => x.Id == id);
        }

        public List<News> GetList()
        {
            return _newsdl.GetAll();
        }

        public void NewsAddBl(News news)
        {
            _newsdl.Insert(news);

        }

        public void NewsDeleteBl(News news)
        {
            _newsdl.Delete(news);
        }

        public void NewsUpdateBl(News news)
        {
            _newsdl.Update(news);
        }
    }
}
