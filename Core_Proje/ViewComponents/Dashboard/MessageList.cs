using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class MessageList : ViewComponent
    {
        MessageManager MessageManager = new MessageManager(new EfMessageDal());
    
        public IViewComponentResult Invoke()
        {
            var values = MessageManager.TGetList();
            return View(values);

        }
    }
}
