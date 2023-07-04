using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Proje_2
{
    public class Board 
    {
        // propgramlamada genellikle ilk once degiskenlerimiz verileri saklayacagimiz yerlerimiz tanimlanir(jargon).Sonra constructor methodu ile ilk degerleri atanip. daha sonra diger metodlar tanimlanir.
        public List<Kart> ToDo { get; set; }

        // Yapilmasi planlanan aktiviteler yukaridaki listede saklanacaktir.
        public List<Kart> InProgress { get; set; }
        // Yapilmaya baslanmis henuz bitmeyen devam eden aktiviteler yukaridaki listededir.
        public List<Kart> Done {get; set; }
        // Tamamlanan aktiviteler yukaridaki listede saklanacaktir.
        public Dictionary<int,String> TakimUyeleri { get; set; }
        // takim uyelerinin isimlerini id numaralari ile eslestirip saklamak mantikli(Key-Value pair mantigi) oldugu icin dictionary olarak verileri sakladim.

        public Board() // Board Class Default Constructor
        {
            ToDo = new List<Kart>();
            InProgress = new List<Kart>();
            Done = new List<Kart>();
            // listenin icerisine deger atamasi yapabilmek icin yukaridaki uc liste icinde birer tane nesne turetildi.

            Kart kart1 = new Kart()
            // Kart classina erisebilmek icin erisim belirleyicisi internal belirlenerek, oradaki degiskenlerin icerisine 3 adet deger verilecek
            // Odevde bizden default degeri olarak (varsayilan olarak 3 tane kart barindirilmali) 3 tane deger vermemizi istedigi icin constructor ile
            // olusturdugumuz degiskenlere deger atayacagiz.
            {
                Baslik = "Patika",
                Icerik = ".Net Core Orta Seviye",
                AtananKisi = "Berk Ozgurcan",
                Buyukluk = KartBuyukluk.L,
                Statu = "ToDo"

            };
            Kart kart2 = new Kart()
            {
                Baslik = "Wissen Academie",
                Icerik = "MVC",
                AtananKisi = "Ahmet Aras",
                Buyukluk= KartBuyukluk.M,
                Statu = "InProgress"
            };
            Kart kart3 = new Kart()
            {
                Baslik = "Wissen Academie",
                Icerik = "SQL",
                AtananKisi = "Hayri Kutlu",
                Buyukluk = KartBuyukluk.S,
                Statu = "Done"
            };

            // Uc tane deger verdigimiz listelerin statulerine gore ToDo,InProgress yada Done listelerine atamalarini yapacagiz.
            ToDo.Add(kart1);
            InProgress.Add(kart2);
            Done.Add(kart3);

            // Yukarida tanimladigimiz uc kisiye ID numaralari verip TakimUyeleri adindaki dictionary icerisinde idleri ile birlikte verileri saklayacagiz.

            TakimUyeleri = new Dictionary<int, string>();
            TakimUyeleri.Add(1, "BerK Ozgurcan");
            TakimUyeleri.Add(2, "Ahmet Aras");
            TakimUyeleri.Add(3, "Hayri Kutlu");
        }
        public void KartEkle()
        {
            Console.WriteLine("Baslik Giriniz: ");
            string baslik = Console.ReadLine();
            Console.WriteLine("Icerik Giriniz: ");
            string icerik = Console.ReadLine();
            Console.WriteLine("Buyukluk Degeri Giriniz(1 den 5e kadar bir sayi giriniz");
            int buyuklukSecilen;
            
            if(int.TryParse(Console.ReadLine(), out buyuklukSecilen) &&  Enum.IsDefined(typeof(KartBuyukluk), buyuklukSecilen))
                // yukaridaki if sartinda ilk once consoldan girilen ifadeyi program sayisal tam sayiya donusturmeye calisicak daha sonra enum tipinde tanimlanan 
                //kartbuyuklukleri icerisinde consoldan girilen ifade ile ayni olan tam sayi var mi yok mu onu kontrol edecek ikinci fonksiyon bool olarak donduruyormus   
            {
                KartBuyukluk buyukluk = (KartBuyukluk)buyuklukSecilen;
                // Kart sinifinin icerisindeki Enum degisken tipindeki KartBuyukluk icerisindeki buyukluk propertysine consoldan girilen integer ifadenin(buyuklukSecilen)
                // Kartbuyukluk enumu icerisindeki anahtarin degerini getirmek icin cast yontemi yapilmistir.

                Console.WriteLine("Olusturdugunuz karti atamak istediginiz kisiyi seciniz.");
                foreach (KeyValuePair<int,string> Takimuyesi in TakimUyeleri)
                {
                    Console.WriteLine($"{Takimuyesi.Key}. {Takimuyesi.Value}");
                }
                // burada daha once constructor tarafindan atadigimiz takimuyelerinin id numaralari ve isimlerini ekrana yazdiriyoruz cunku bu listeden secim 
                // yapilarak kullanicinin yanlis bir deger girmesini onlemek icin
                int secilenKisiID;
                if(int.TryParse(Console.ReadLine(),out secilenKisiID) && TakimUyeleri.ContainsKey(secilenKisiID))
                    // burda yine ayni sekilde tryparse methodu ile konsoldan gelen deger eger integer ise secilenkisiId ye o degeri ata(out) ve TakimUyeleri icerisinde
                    // atanan integer degeri takimuyeleri listesinde bulursan islemi gerceklestir.
                {
                    string atananKisi = TakimUyeleri[secilenKisiID];
                    Kart yenikart = new Kart()
                    {
                        Baslik = baslik,
                        Icerik = icerik,
                        AtananKisi = atananKisi,
                        Buyukluk = buyukluk,
                        Statu = "ToDo"
                    };
                    ToDo.Add(yenikart);
                    Console.WriteLine("Kart eklendi.");
                }
                else
                {
                    Console.WriteLine("Girdiginiz id numarasinda kisi bulunamadi");
                }

            }
            else
            { Console.WriteLine("Buyukluk deger araligi 1 ile 5 arasindadir lutfen 1 ile 5 arasinda bir tamsayi degeri giriniz..")};

        }
        public void KartSil()
        {
          
            Console.WriteLine("Silmek istediginiz kartin basligini yazinizi");
            string baslik = Console.ReadLine();
            List<Kart> silinecekKartlar = new List<Kart>();
            // Konsoldan baslik degeri alinip, bir silinecek kartlari koyacagimiz bir liste tanimladik.
            foreach (Kart kart in ToDo)
            {
                if(kart.Baslik.ToLower() == baslik.ToLower())
                {
                    silinecekKartlar.Add(kart);
                    ToDo.Remove(kart);
                }
            }
            // yukarida for each ile todo listesinin icerisindeki tum kartlar aranarak, if ile basligi konsoldan girilen baslikla ayni ise konsoldan
            //girilen karti silinecekkartlar listesine ekle dendi. Buradala ToLower methodu kullanilmasi nedeni kullanicinin girdigi degeri case sensitive
            // olarak girmesse program bulamayacagindan tum harfleri kucuk harfe cevirip arama yaptirdik.
            foreach (Kart kart in InProgress)
            {
                if (kart.Baslik.ToLower() == baslik.ToLower())
                {
                    silinecekKartlar.Add(kart);
                    InProgress.Remove(kart);
                }
            }
            foreach (Kart kart in Done)
            {
                if (kart.Baslik.ToLower() == baslik.ToLower())
                {
                    silinecekKartlar.Add(kart);
                    Done.Remove(kart);

                }
            }
            //Yukarida kartlar icin uc ayri liste olusturdugumuz icin uc listede arama yapmak zorunda olduk. Aslinda iyibir UML Class Diagram olmadi,daha iyi bir
            // diagram ile program gelistirilebilir.
            Console.WriteLine("Silme islemi gerceklestirildi.");

        }
        public void KartTasi()
        {
            Console.WriteLine("Tasimak istediginiz kartin basligini yaziniz");
            string baslik = Console.ReadLine();
            // Consoldan tasinmak istenen kartin baslik bilgisi alindi.

            Kart secilenKart;

            foreach (Kart kart in ToDo)
            {
                if (kart.Baslik.ToLower() == baslik.ToLower())
                {
                    secilenKart = kart;
                    break;
                }
            }
            // ilk once secilen kart basligi todo listesinde var mi arandi eger varsa secilen kart degerinin icerisine atayip veriyi tutar.

            if (secilenKart == null)
                // burada eger secilen kart degeri yukaridaki to do listesinde yoksa demek istedim.
            {
                foreach (Kart kart in InProgress) 
                {
                    if ( kart.Baslik.ToLower() == baslik.ToLower())
                    {
                        secilenKart = kart;
                        break;
                    }
                }
                // eger todo listesinde yoksa in progress listesinde arar bulursa bulunan deger secilen kart degerinin icine atanir.
            }
            if(secilenKart == null)
            {
                // eger yukaridaki iki listedede bulunamazsa en son liste done listesinde arama yapilir.
                foreach(Kart kart in Done)
                {
                    if(kart.Baslik.ToLower() == baslik.ToLower())
                    {
                        secilenKart = kart;
                        break;
                    }
                }
                // en son done listesinin icerisindede arama yapildi
            }
            if(secilenKart != null)
                // eger girilen deger dogru ise yukaridaki if blocklarinin birinin icerisine girip degeri alacagindan secilenkart null olmaz eger null ise 
                // dogru deger girilmemistir.
            {
                Console.WriteLine("Bulunan Kart Bilgileri:");
                Console.WriteLine("**************************************");
                Console.WriteLine($"Başlık      : {secilenKart.Baslik}");
                Console.WriteLine($"İçerik      : {secilenKart.Icerik}");
                Console.WriteLine($"Atanan Kişi : {secilenKart.AtananKisi}");
                Console.WriteLine($"Büyüklük    : {secilenKart.Buyukluk}");
                Console.WriteLine($"Statu       : {secilenKart.Statu}");
                Console.WriteLine();

                Console.WriteLine("Lütfen taşımak istediğiniz Line'ı seçiniz:");
                Console.WriteLine("(1) TODO");
                Console.WriteLine("(2) IN PROGRESS");
                Console.WriteLine("(3) DONE");

                string secim = Console.ReadLine();

                switch(secim )
                {
                    case "1":
                        if (secilenKart.Statu != "TODO")
                        {
                            if (secilenKart.Statu == "IN PROGRESS")
                            {
                                InProgress.Remove(secilenKart);
                            }
                            else if (secilenKart.Statu == "DONE")
                            {
                                Done.Remove(secilenKart);
                            }
                        }
                        else { Console.WriteLine("Secilen Kart Zaten"); }
                        

                        secilenKart.Statu = "TODO";
                        ToDo.Add(secilenKart);
                        Console.WriteLine("Kart Tasindi.");
                        break;

                    case "2":
                        if(secilenKart.Statu != "IN PROGRESS")
                        {
                            if(secilenKart.Statu == "TODO")
                            {
                                ToDo.Remove(secilenKart);
                            }
                            else if(secilenKart.Statu == "DONE")
                            {
                                Done.Remove(secilenKart) ;
                            }
                            secilenKart.Statu = "IN PROGRESS";
                            InProgress.Add(secilenKart);

                            Console.WriteLine("Kart Tasindi.");
                        }
                        else { Console.WriteLine("Secilen Kart Zaten IN PROGRESS statusundedir"); }
                        break;

                    case "3":
                        if(secilenKart.Statu != "DONE")
                        {
                            if(secilenKart.Statu == "TODO")
                            {
                                ToDo.Remove(secilenKart);
                            }
                            else if (secilenKart.Statu == "IN PROGRESS")
                            {
                                InProgress.Remove(secilenKart);
                            }
                            secilenKart.Statu = "DONE";
                            Done.Add(secilenKart);
                            Console.WriteLine("Kart tasindi.");
                        }
                        else { Console.WriteLine("Secili Kart Zaten Done Statusundedir"); }
                        break;


                }
            }
        }



    }

}
