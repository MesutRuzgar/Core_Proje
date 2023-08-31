using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Models
{
    public class UserMessageViewModel
    {
        public int WriterMessageId { get; set; }
        public string SenderName { get; set; }
        public string MessageContent { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; }
    }
}
