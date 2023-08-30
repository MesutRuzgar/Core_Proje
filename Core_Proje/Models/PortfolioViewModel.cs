using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Models
{
    public class PortfolioViewModel
    {
        public int PortfolioId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Picture { get; set; }
        public string ProjectUrl { get; set; }
        public string ImageUrl2 { get; set; }
        public IFormFile Picture2 { get; set; }
        public string Platform { get; set; }
        public string Price { get; set; }
        public bool Status { get; set; }
        public int Value { get; set; }
    }
}
