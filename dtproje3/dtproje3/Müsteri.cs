using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dtproje3
{
   

    class Müsteri
    { 
        static Random r = new Random();
        private int id;
        string kiralamaSaati;

        public Müsteri()//constructor
        {
            id = r.Next(1, 20);
            int saat = r.Next(0, 24);
            int dakika = r.Next(0, 60);
            //id,saat ve dakikayı random oluşturdum
            kiralamaSaati=saatDüzenle(saat, dakika);
           
            
        }
       
        public Müsteri(int id)//constuctor
        {
            this.id = id;
            int saat = r.Next(0, 24);
            int dakika = r.Next(0, 60);
            kiralamaSaati=saatDüzenle(saat, dakika);
        }

        public string saatDüzenle(int saat, int dakika)
        {
            string kiralamaSaati1;
            if (saat < 10 && dakika >= 10)//sadece saat tek basamaklı ise başına 0 ekledim
            {
                string saat1 = saat.ToString();//0'ıstring gibi eklemek istediğim için saati de string yaptım
                saat1 = "0" + saat1;
                kiralamaSaati1 = saat1 + ":" + dakika;
            }
            else if (saat >= 10 && dakika < 10) //sadece dakika tek basamaklı ise başına 0 ekledim
            {
                string dakika1 = dakika.ToString();//dakikayı string yaptım
                dakika1 = "0" + dakika1;
                kiralamaSaati1 = saat + ":" + dakika1;
            }
            else if (saat < 10 && dakika < 10)//ikisi de tek basamaklı ise
            {
                string saat2 = saat.ToString();
                saat2 = "0" + saat2;
                string dakika2 = dakika.ToString();
                dakika2 = "0" + dakika2;
                kiralamaSaati1 = saat2 + ":" + dakika2;
            }
            else
            {//ikisi de çift basamaklı 
                kiralamaSaati1 = saat + ":" + dakika;//değişiklik yok

            }
            return kiralamaSaati1;
        }
        
        public int getId()
        {
            return id;
        }
        public void setIdBilgi(int id)
        {
            this.id = id;
        }
        
        
        public void yazdir()
        {   

            Console.WriteLine( "Id:" +""+getId()+" Kiralama Saati: "+kiralamaSaati);
            Console.WriteLine("***************************");
        }
    }
}
