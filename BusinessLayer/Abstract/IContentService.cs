using EntityLayer.Concreat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> ContentGettListBl();
        
        void ContentAddBl(Content content);

        Content ContentGetByIdBl(int id);
       
        void ContentDeleteBl(Content content);
        
        void ContentUpdateBl(Content content);
        
        List<Content> GetListByHeadingId(int id);
        

        


    }
}
