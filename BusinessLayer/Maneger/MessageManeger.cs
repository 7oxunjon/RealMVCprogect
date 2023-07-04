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
    public class MessageManeger : IMessageService
    {
        IMessageDl _message;

        public MessageManeger(IMessageDl message)
        {
            _message = message;
        }

        public List<Message> GetListInbox()
        {
            return _message.List(x => x.Qabul_qiluvchiMail == "Admin@gmail.com"); 
        }

        public Message GetById(int id)
        {
            return _message.Get(x=>x.MessageId== id);
        }

        
        public List<Message> GetListSendbox()
        {
            return _message.List(x => x.YuboruvchiMail == "Admin@gmail.com");
        }


        public void MessageAdd(Message message)
        {
            _message.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
