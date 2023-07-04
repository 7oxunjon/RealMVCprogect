using BusinessLayer.Abstract;
using DataAsseccLayer.Repostory.Interfase;
using EntityLayer.Concreat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Maneger
{
    public class AboutManager : IAboutService
    {
        IAboutDl _about;

        public AboutManager(IAboutDl about)
        {
            _about = about;
        }

        public void AboutAdd(About about)
        {
            _about.Insert(about);
        }

        public void AboutDelete(About about)
        {
            _about.Delete(about);
        }

        public void AboutUpdate(About about)
        {
            _about.Update(about);
        }

        public About GetById(int id)
        {
            return _about.Get(x => x.AboutId == id);
        }

        public List<About> GetList()
        {
            return _about.GetAll();
        }
    }
}
