using EntityLayer.Concreat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        About GetById(int id);

        List<About> GetList();
        
        void AboutUpdate(About about);
        
        void AboutDelete(About about);
        
        void AboutAdd(About about);
    }
}
