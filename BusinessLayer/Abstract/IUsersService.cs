using EntityLayer.Concreat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUsersService
    {
        List<Users> GetList();

        Users GetById(int id);  
        
        void UsersAddBl(Users user);
        
        void UsersDeleteBl(Users user);
        
        void UsersUpdateBl(Users users);
    }
}
