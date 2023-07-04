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
    public class WriterMeneger : IWriterService
    {
        IWriterDl _writerDl;

        public WriterMeneger(IWriterDl writerDl)
        {
            _writerDl = writerDl;
        }

        public Writer GetById(int id)
        {
            return _writerDl.Get(x => x.WriterId == id);
        }

        public List<Writer> GetList()
        {
            return _writerDl.GetAll();
        }

        public void WriterAddBl(Writer writer)
        {
            _writerDl.Insert(writer);
        }

        public void WriterDeleteBl(Writer writer)
        {
            _writerDl.Delete(writer);
        }

        public void WriterUpdeteBL(Writer writer)
        {
           _writerDl.Update(writer);
        }
    }
}
