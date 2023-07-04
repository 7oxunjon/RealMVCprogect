using EntityLayer.Concreat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingServies
    {
        List<Heading> GetList();

        Heading GetById(int id);

        void HeadingAddBl(Heading heading);

        void HeadingDeleteBl(Heading heading);

        void HeadingUpdateBl(Heading heading);
    }
}
