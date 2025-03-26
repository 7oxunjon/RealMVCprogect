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
    public class UsersManeger : IUsersService
    {
        IUserDl _userDl;

        public UsersManeger(IUserDl userDl)
        {
            _userDl = userDl;
        }

        public Users GetById(int id)
        {
            return _userDl.Get(x => x.id == id);
        }

        public List<Users> GetList()
        {
            return _userDl.GetAll();
        }

        public void UsersAddBl(Users user)
        {
            _userDl.Insert(user);
        }

        public void UsersDeleteBl(Users user)
        {
            _userDl.Delete(user);
        }

        public void UsersUpdateBl(Users users)
        {
            _userDl.Update(users);
        }
    }
}
