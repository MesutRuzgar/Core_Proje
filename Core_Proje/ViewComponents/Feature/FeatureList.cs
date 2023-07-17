﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.ViewComponents.Feature
{
    public class FeatureList : ViewComponent
    {
        //viewcomponentresult lar genel olarak Invoke olarak isimlendirilir
        public IViewComponentResult Invoke()
        {
            return View();

        }
        //Yukarıda ki kodları yazınca FeatureList adını kopyala. Solutiıon da bulunan
        //Views klasörü içerisindeki "Shared" klasörüne sağ tıkla önce bir "Components" adında
        //bir klasör oluştur. içerisine kopyaladığımız isimde bir klasör oluştur.
        //Bunun amacı Invoke komutuna bağlı olarak çalışan viewleri
        //view klasöründe bulunan shared klasörü içerisindeki components klasörü içinde  arayacağız.
        //daha sonra featureliste sağ tıklayıp bir view oluştur ve partial seçeneği işaretli olsun
        //view'in ismi Default olmak zorunda!!!!
        //bu uyguladığımız methodda bunları yapmak zorundayız.
        //index alanında çağırmak için ise  @await Component.InvokeAsync("FeatureList") kullanıyoruz.
        //component'in amacı html de direkt olarak erişimi engellemektir
        //mesala sonuna ..../navbarpartial yazdığımızda sayfaya erişilir ancak
        //componentslere erişilmez.
    }
}
