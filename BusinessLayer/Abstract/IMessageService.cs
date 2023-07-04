using EntityLayer.Concreat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        Message GetById(int id);

        List<Message> GetListInbox();

        List<Message> GetListSendbox();

        void MessageUpdate(Message message);

        void MessageDelete(Message message);

        void MessageAdd(Message message);

    }
}
