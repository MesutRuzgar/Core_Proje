using BusinessLayer.Concrete;
using Core_Proje.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class AdminNavbarMessageList : ViewComponent
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            string p = "deneme@deneme.com";
            var values = writerMessageManager.GetListReceiverMessage(p).Where(x => x.Status == false).OrderByDescending(x => x.WriterMessageId).Take(3).ToList();
           
            //list olusturmamizin sebebi yukarida liste almamiz
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
                };
                messageViewModels.Add(model);

            }
            return View(messageViewModels);
        }

     

    }

}

