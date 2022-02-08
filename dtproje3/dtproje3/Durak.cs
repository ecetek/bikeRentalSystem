using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dtproje3
{
    class Durak
    {
        List<Durak> durakNesneleri=new List<Durak>();
        string durakAdi;
        private int bosPark, tandemBisiklet, normalBisiklet;
       


        public Durak()//metodları çağıracağım zaman kullanacağım
        {

        }
        public Durak(string durakAdi,int bosPark, int tandemBisiklet, int normalBisiklet)//parametreli constructor
        {
            this.durakAdi = durakAdi;
            this.bosPark = bosPark;
            this.tandemBisiklet = tandemBisiklet;
            this.normalBisiklet = normalBisiklet;
            

        }

        public int getBosPark()
        {
            return bosPark;
        }

        public void setBosPark(int bosPark)
        {
            this.bosPark = bosPark;
        }

        public int getTandemBisiklet()
        {
            return tandemBisiklet;
        }

        public void setTandemBisiklet(int tandemBisiklet)
        {
            this.tandemBisiklet = tandemBisiklet;
        }

        public int getNormalBisiklet()
        {
            return normalBisiklet;
        }

        public void setNormalBisiklet(int normalBisiklet)
        {
            this.normalBisiklet = normalBisiklet;
        }

        public string getDurakAdi()
        {
            return durakAdi;
        }

        public void setDurakAdi(string durakAdi)
        {
            this.durakAdi = durakAdi;
        }
        public List<Durak> durakNesneleriCagir()
        {
            return durakNesneleri;//main'de kopyasını tutmak için oluşturdum
        }
        
        public int[] ozelliklerCagir()
        {// hashtable için value kısmında bisiklet bilgileri int dizi şeklinde tutulması için main'de kullanacağız

            int []ozellikler = {getBosPark(), getTandemBisiklet(), getNormalBisiklet() };
            return ozellikler;
        }
      

        public void nesneOlustur(String[] duraklar)
        {   
            for(int i = 0; i < duraklar.Length; i++)
            {
                string[] words = duraklar[i].Split(',');//dizideki string tipindeki bilgileri diziye atadım
                Durak durak = new Durak(words[0], Int32.Parse(words[1]), Int32.Parse(words[2]), Int32.Parse(words[3]));//dizinin her bir elemanını nesneye atadım
                durakNesneleri.Add(durak);//generic list'e ekledim
            }
            
        }
        
        public Müsteri kiralamaIslemi(Durak durak,int id)//kullanıcının belirttiği duraktan,belirttiği ıd'ye göre kiralama işlemi
        {
            Müsteri musteri1 = new Müsteri(id);//müşteri nesnesi oluşturdum,ağaca eklenecek
            durak.bosPark = durak.bosPark + 1;//baş park sayısı güncelle
            durak.normalBisiklet = durak.normalBisiklet - 1;
            if (durak.normalBisiklet <= 0)
            {
                durak.normalBisiklet +=1;//normal bisiklet sayısı 0'a eşit veya küçükse kiralamadan önceki haline döndürdüm
                durak.tandemBisiklet = durak.tandemBisiklet-1; //tandem üzerinden işlem yaptım
                if (durak.tandemBisiklet <= 0)
                {
                    durak.tandemBisiklet = 0;

                }
                
            }
            musteri1.yazdir();
            return musteri1;
        }

        public void nesneGuncelle(int r,Durak durak)
        {
            durak.bosPark = durak.bosPark + r;//müteri sayısına kadar boş park sayısı artar
            durak.normalBisiklet = durak.normalBisiklet - r;
            if (durak.normalBisiklet < 0)
            {
                durak.normalBisiklet +=r;
                durak.tandemBisiklet = durak.tandemBisiklet - r;
                if (durak.tandemBisiklet <= 0)
                {
                    
                    durak.tandemBisiklet = 0;

                }
                
            }
            
        }
        public void yazdir()//node için işime yarayacak
        {
            Console.WriteLine(String.Format("{0,-14}{1,-11}{2,-17}{3,-17}", "Durak Adı ","Boş Park ", "Tandem Bisklet ","Normal Bisiklet "));
            Console.WriteLine(String.Format("{0,-14}{1,-11}{2,-16}{3,-16}", "--------- ","-------- ", "---------------  ","-------------- "));
            Console.WriteLine(String.Format("{0,-18}{1,-11}{2,-17}{3,-17}" ,durakAdi.ToUpper() , bosPark , tandemBisiklet  , normalBisiklet));
            
        }
        
    }
}
