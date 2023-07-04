using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje_2
{
    internal class BoardListeleme
    {
        Board board1 = new Board();
        public void BoardListele()
        {
            Console.WriteLine("TODO Line");
            Console.WriteLine("************************");

            foreach (Kart kart in ToDo)
            {
                Console.WriteLine($"Başlık      : {kart.Baslik}");
                Console.WriteLine($"İçerik      : {kart.Icerik}");
                Console.WriteLine($"Atanan Kişi : {kart.AtananKisi}");
                Console.WriteLine($"Büyüklük    : {kart.Buyukluk}");
                Console.WriteLine("-");
            }

            Console.WriteLine("IN PROGRESS ");
            Console.WriteLine("************************");

            foreach (Kart kart in InProgress)
            {
                Console.WriteLine($"Başlık      : {kart.Baslik}");
                Console.WriteLine($"İçerik      : {kart.Icerik}");
                Console.WriteLine($"Atanan Kişi : {kart.AtananKisi}");
                Console.WriteLine($"Büyüklük    : {kart.Buyukluk}");
                Console.WriteLine("-");
            }

            Console.WriteLine("DONE ");
            Console.WriteLine("************************");

            foreach (Kart kart in Done)
            {
                Console.WriteLine($"Başlık      : {kart.Baslik}");
                Console.WriteLine($"İçerik      : {kart.Icerik}");
                Console.WriteLine($"Atanan Kişi : {kart.AtananKisi}");
                Console.WriteLine($"Büyüklük    : {kart.Buyukluk}");
                Console.WriteLine("-");
            }
        }
    }
}
