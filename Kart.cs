using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje_2
{
    public enum KartBuyukluk
    {
        XS=1,
        S,
        M,
        L,
        XL,
    }
    // Kart buyuklukleri enum olarak tanimlandi. Odevde ozellikle oyle istenmis.
    // Enumlar ve structlar siniftan bagimsiz olarak siniflarin uzerinde tanimlaniyor genelde, burda class acmaya gerek yok cunku sadece herhangi bir metod ihtiyaci yok.
    // class enumlari kapsar, ayri bir class da acilabilirdi fakat kucuk bir islem yaptigimiz icin classlarin ozelliklerine ihtiyacimiz olmadigindan enum tanimlamak dogru.
    internal class Kart
    {
        public string Baslik { get; set; }    
        public string Icerik { get; set; }

        public string AtananKisi { get; set; }

        public KartBuyukluk Buyukluk { get; set; }

        public string Statu { get; set; }

        // Her kartin icerisinde olmasi gereken nitelikler(fieldler) tanimlandi. Property olarak degiskenlerimizi tanimladik.

    }
}
