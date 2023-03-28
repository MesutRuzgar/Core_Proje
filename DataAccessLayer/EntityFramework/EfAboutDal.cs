using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAboutDal : GenericRepository<About>, IAboutDal
    {
        //IAboutDal eklememizin sebebi normal crud işlemleri dışında sadece bu entities'e ait  bir işlem gerçekleştirmek istersek imzasını IAboutDal'da atıp içini burada dolduracağız bu sayede bağımsız olacak.
    }
}
