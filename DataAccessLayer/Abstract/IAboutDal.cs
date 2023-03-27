using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IAboutDal
    {
        void Insert(About p);
        void Delete(About p);
        void Update(About p);
        List<About> GetList();
    }
}
