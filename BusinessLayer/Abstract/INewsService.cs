using EntityLayer.Concreat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface INewsService
    {
        List<News> GetList();

        News GetById(int id);
        
        void NewsAddBl(News news);
        
        void NewsDeleteBl(News news);

        void NewsUpdateBl(News news);
    }
}
