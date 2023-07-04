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
    public class ImageFileManeger : IImageFileServise
    {
        IImageFileDal Dal;

        public ImageFileManeger(IImageFileDal dal)
        {
            Dal = dal;
        }

        public List<ImageFile> GetList()
        {
            return Dal.GetAll(); 
        }
    }
}
