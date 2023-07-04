using BusinessLayer.Maneger;
using BusinessLayer.ValidationRele;
using DataAsseccLayer.EntityFramework;
using EntityLayer.Concreat;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace RealMVCprogect.Controllers
{
    public class MessageController : Controller
    {
        MessageManeger message = new MessageManeger(new EfMessageDl());
        MessageValidator messagevalidator = new MessageValidator();
       

        public IActionResult Inbox()
        {
            var messager = message.GetListInbox();
            return View(messager);
        }

        public IActionResult SendBox()
        {
            var messager = message.GetListSendbox();
            return View(messager);
        }

        public IActionResult GetInboxMessageDetails(int Id)
        {
            var value = message.GetById(Id); 
            return View(value);

        }


        public IActionResult GetSentMessageDetails(int Id)
        {
            var value = message.GetById(Id);
            return View(value);

        }


        [HttpGet]
        public IActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewMessage( Message _message)
        {
            ValidationResult result = messagevalidator.Validate(_message);
            if (result.IsValid)
            {
                _message.MessageDate = DateTime.SpecifyKind(_message.MessageDate, DateTimeKind.Unspecified);
                _message.MessageDate = _message.MessageDate.ToUniversalTime();


                message.MessageAdd(_message);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();


           
        }
    }
}
