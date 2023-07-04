using EntityLayer.Concreat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        Contact ContactById (int id);
        
        List<Contact>GetList();
        
        void ContactUpdateBl(Contact contact);
        
        void ContactAddBl(Contact contact);   
        
        void ContactDeleteBl(Contact contact);

        

    }
}
