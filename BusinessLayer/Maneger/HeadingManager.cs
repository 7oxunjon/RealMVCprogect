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
    public class HeadingManager : IHeadingServies
    {
        IHeadingDl _dl;

        public HeadingManager(IHeadingDl dl)
        {
            _dl = dl;
        }

        public List<Heading> GetList()
        {
           return _dl.GetAll();
        }

        public Heading GetById(int id)
        {
            return _dl.Get(x => x.HeadingId == id);
        }

        public void HeadingAddBl(Heading heading)
        {
            _dl.Insert(heading);
        }

        public void HeadingDeleteBl(Heading heading)
        {
           
            _dl.Update(heading);
        }

        public void HeadingUpdateBl(Heading heading)
        {
            _dl.Update(heading); 
        }
    }
}
