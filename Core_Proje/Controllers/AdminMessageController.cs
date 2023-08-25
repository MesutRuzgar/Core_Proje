using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Controllers
{
    public class AdminMessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        public IActionResult ReceiverMessageList()
        {
            string p;
            p = "deneme@deneme.com";
            var values = writerMessageManager.GetListReceiverMessage(p);
            return View(values);
        }
        public IActionResult SenderMessageList()
        {
            string p;
            p = "deneme@deneme.com";
            var values = writerMessageManager.GetListSenderMessage(p);
            return View(values);
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
            writerMessageManager.TAdd(p);           
            return RedirectToAction("SenderMessageList");
        }
    }
}
