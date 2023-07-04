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
    public class ContentManager : IContentService
    {
        IContentDl ContentDl;

        public ContentManager(IContentDl contentDl)
        {
            ContentDl = contentDl;
        }

        public void ContentAddBl(Content content)
        {
            ContentDl.Insert(content);
        }

        public void ContentDeleteBl(Content content)
        {
            ContentDl.Delete(content);
        }

        public Content ContentGetByIdBl(int id)
        {
           return ContentDl.Get(x => x.ContentId == id);
        }

        public List<Content> GetListByHeadingId(int id)
        {
           return ContentDl.List(x => x.HeadingId == id);
        }

        public List<Content> ContentGettListBl()
        {
            return ContentDl.GetAll();
        }

        public void ContentUpdateBl(Content content)
        {
            ContentDl.Update(content); 
        }
    }
}
