namespace Proje_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool dongu;
            do
            {
            // Console ToDo Uygulamasi
            Console.WriteLine("Lutfen yapmak istediginiz islemi seciniz");
            MenuGoster();
            
            int secim = Convert.ToInt32(Console.ReadLine());
            
            try
            {
                switch (secim)
                {
                    case 1:
                      
                        BoardListeleme boardlisteleme = new BoardListeleme();
                        boardlisteleme.BoardListele();
                        break;
                    case 2:
                        Board board = new Board();
                        board.KartEkle();
                        
                        break;
                    case 3:
                        Board board1 = new Board();
                        board1.KartSil();

                        break; 
                    case 4:
                        Board board2 = new Board();
                        board2.KartTasi();
                        break;
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Lutfen gecerli bir deger girin"); ;
            }
            Console.WriteLine("Uygulamadan cikmak istiyor musunuz e/h");
                char tercih;
                
                tercih = Convert.ToChar(Console.ReadLine());
                if ( tercih == 'e')
                {
                    dongu = true;
                }
                else 
                {
                    dongu= false;
                }

            } while (dongu);


        }    
        public static void MenuGoster()
        {
            Console.WriteLine(" 1- Board Listeleme \n 2-Board'a Kart Eklemek \n 3- Kart Sil \n 4- Kart Tasi");
        }

    }
}