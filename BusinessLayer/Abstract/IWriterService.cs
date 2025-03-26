using EntityLayer.Concreat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetList();

        Writer GetById(int id);
        
            void WriterAddBl(Writer writer);
        
            void WriterDeleteBl(Writer writer);
        
            void WriterUpdeteBL(Writer writer);

    }
}
