using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Models
{
    public class TestimonialViewModel
    {
        public int TestimonialId { get; set; }
        //referans adı için clientname kullandık
        public string ClientName { get; set; }
        public string Company { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Picture { get; set; }
    }
}
