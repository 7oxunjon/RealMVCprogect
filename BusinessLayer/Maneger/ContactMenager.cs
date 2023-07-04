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
    public class ContactMenager : IContactService
    {
        IContactDl _con;

        public ContactMenager(IContactDl con)
        {
            _con = con;
        }

        public Contact ContactById(int id)
        {
            return _con.Get(x => x.ContactId == id);
        }

        public void ContactAddBl(Contact contact)
        {
            _con.Insert(contact);
        }

        public void ContactDeleteBl(Contact contact)
        {
            _con.Delete(contact);
        }

        public void ContactUpdateBl(Contact contact)
        {
            _con.Update(contact);
        }

        public List<Contact> GetList()
        {
            return _con.GetAll();
        }
    }
}
