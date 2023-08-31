using BusinessLayer.Concrete;
using Core_Proje.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        public IActionResult ReceiverMessageList()
        {
            string p;
            p = "deneme@deneme.com";
            var values = writerMessageManager.GetListReceiverMessage(p);
            List<UserMessageViewModel> messageReceiverViewModels = ViewMessage(values);
            return View(messageReceiverViewModels);
        }

        public IActionResult SenderMessageList()
        {
            string p;
            p = "deneme@deneme.com";
            var values = writerMessageManager.GetListSenderMessage(p);
            List<UserMessageViewModel> messageSenderViewModels = ViewSenderMessage(values);
            return View(messageSenderViewModels);
           
        }
        public IActionResult ReceiverMessageDetails(int id)
        {
            WriterMessage writerMessage = writerMessageManager.TGetById(id);
            return View(writerMessage);
        }

        public IActionResult SenderMessageDetails(int id)
        {
            WriterMessage writerMessage = writerMessageManager.TGetById(id);
            return View(writerMessage);
        }
       
        public IActionResult DeleteMessage(int id)
        {
            string p;
            p = "deneme@deneme.com";
            var values = writerMessageManager.TGetById(id);
           
            if (values.Receiver==p)
            {
                writerMessageManager.TDelete(values);
                return RedirectToAction("ReceiverMessageList");
            }
            else
            {
                writerMessageManager.TDelete(values);
                return RedirectToAction("SenderMessageList");
            }
            
        }
        [HttpGet]
        public IActionResult AdminMessageSend()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminMessageSend(WriterMessage p)
        {
            p.Sender = "deneme@deneme.com";
            p.SenderName = "Mesut Rüzgar";
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            writerMessageManager.TAdd(p);           
            return RedirectToAction("SenderMessageList");
        }

        private static List<UserMessageViewModel> ViewMessage(List<WriterMessage> values)
        {
            Context c = new Context();
            List<UserMessageViewModel> messageViewModels = new List<UserMessageViewModel>();
            foreach (var item in values)
            {
                var user = c.Users.Where(x => x.Email == item.Sender).FirstOrDefault();
                var model = new UserMessageViewModel
                {
                    ImageUrl = user.ImageUrl,
                    Date = item.Date,
                    MessageContent = item.MessageContent,
                    SenderName = item.SenderName,
                    WriterMessageId = item.WriterMessageId,
                    Subject=item.Subject,
                };
                messageViewModels.Add(model);

            }

            return messageViewModels;
        }
        private static List<UserMessageViewModel> ViewSenderMessage(List<WriterMessage> values)
        {
            Context c = new Context();
            List<UserMessageViewModel> messageViewModels = new List<UserMessageViewModel>();
            foreach (var item in values)
            {
                var user = c.Users.Where(x => x.Email == item.Receiver).FirstOrDefault();
                var model = new UserMessageViewModel
                {
                    ImageUrl = user.ImageUrl,
                    Date = item.Date,
                    MessageContent = item.MessageContent,
                    SenderName = item.SenderName,
                    WriterMessageId = item.WriterMessageId,
                    Subject = item.Subject,
                    ReceiverName = item.ReceiverName
                };
                messageViewModels.Add(model);

            }

            return messageViewModels;
        }

    }
}
