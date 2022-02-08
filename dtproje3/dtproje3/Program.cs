using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dtproje3
{
    class Program
    {   
        
        static void Main(string[] args)
        {
            List<Durak> durakNesneleriKopya = new List<Durak>();//nesne eklemek için kullanacağım
            string[] duraklar = { "İnciraltı,20,8,15","Sahilevleri,8,6,18","Doğal Yaşam Parkı,17,3,10","Bostanlı İskele,7,4,5","Alsancak İskele,10,2,9","Karantina,9,2,5","Konak Metro,2,7,18","Susuzdede,9,3,6","Fuar Basmane,10,3,5"}; 
            Durak durak = new Durak();
            durak.nesneOlustur(duraklar);
            durakNesneleriKopya = durak.durakNesneleriCagir();
            Tree agac = new Tree();
            Heap theHeap = new Heap(duraklar.Length);
            Hashtable hashtable = new Hashtable();
            foreach (Durak nesne in durakNesneleriKopya)
            {
                agac.insert(nesne);
                hashtable.Add(nesne.getDurakAdi(), nesne.ozelliklerCagir());
                theHeap.insert(nesne);
               
            }
            theHeap.displayHeap();
            Console.Read();
            theHeap.maxIstasyonBilgi(3);
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("Agacın PostOrder Dolaşılması : ");
            agac.postOrderYazdir(agac.getRoot());
            agac.findAndWriteTreeInfo(agac.getRoot());
            Console.WriteLine("\nKiralama işlemi: ");
            agac.kirala(agac.getRoot(),"Karantina",4);
            int idNo2=sayiAl();
            Console.WriteLine("\nGirilen ID'ye göre bilgiler:");
            agac.IdBilgi(agac.getRoot(), idNo2);
            Console.ReadLine();
            Console.WriteLine(" Hashtable Tablosu: ");
            hashYazdir(hashtable);
           
            foreach (int[] dizi1 in hashtable.Values)//hashtable üzerinde güncelleme işlemleri yaptım
            {

                if (dizi1[0] > 5)//boş park sayısı 5'ten fazla ise normal bisiklet sayısına 5 ekledim
                {
                    dizi1[0]-= 5;
                    dizi1[2] += 5;
                }
             
            }
            
            Console.WriteLine("Bisiklet sayısına göre güncelleme işlemleri tamamlandıktan sonraki hali :");
            hashYazdir(hashtable);
            MyArray array1 = new MyArray(15);
            array1.arrayBilgiYazdir();
        }

        static int  sayiAl()
        {

            string idNo;
            Console.Write("1-20 arasında tamsayı değerde ID giriniz : ");
            int idNo1;
            try
            {
                
                idNo = Console.ReadLine();//str olarak alınır
                idNo1 = Convert.ToInt32(idNo);//int çevirdim
                if (idNo1 <= 0)
                {
                    Console.WriteLine("Lütfen 0'dan büyük bir değer giriniz!");
                    idNo1 = sayiAl();
                }
                return idNo1;
            }
            catch(FormatException)
            {
                
                Console.WriteLine("Lütfen  bir değer giriniz!");
                idNo1 = sayiAl();
                return idNo1;

            }
            

        }
        static void hashYazdir(Hashtable hashtable)
        {
            
            Console.WriteLine(String.Format("{0,-20}{1,-15}{2,-18}{3,-18}", "Durak Adı ", "Boş Park ", "Tandem Bisiklet ", "Normal Bisiklet "));
            Console.WriteLine(String.Format("{0,-20}{1,-15}{2,-18}{3,-18}", "--------- ", "-------- ", "--------------- ", "--------------- "));

            foreach (DictionaryEntry eleman in hashtable)
            {

                int[] dizi = (int[])eleman.Value;//hizalı şekilde yazdırabilmek için
                Console.WriteLine(String.Format("{0,-22}{1,-19}{2,-20}{3,-20}", eleman.Key, dizi[0], dizi[1], dizi[2]));

            }
            Console.ReadLine();
        }
        
       
    }
}
