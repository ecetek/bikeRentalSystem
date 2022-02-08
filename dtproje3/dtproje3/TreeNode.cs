using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dtproje3
{
    class TreeNode
    {
        public Durak data;
        public TreeNode leftChild;
        public TreeNode rightChild;
        public List<Müsteri> musteriler = new List<Müsteri>();//müşterileri tuttum

        public void istasyonBilgi()//kiralama işlemi sonrası bilgileri yazdırır
        {
            Console.WriteLine(data.getDurakAdi()+" adlı istasyondan kiralandı!");
            Console.WriteLine("\n");
        }

        
        public void displayNode() { 
            data.yazdir();//durak bilgileri
            Console.WriteLine("\nKİRALAMA BİLGİLERİ : ");
            int musteriSayisi = 0;
            foreach(Müsteri musteri in musteriler)
            {
                musteri.yazdir();
                musteriSayisi++;
                
            }
            Console.WriteLine(musteriSayisi + " müşteri kiralama işlemi yaptı!");
            Console.ReadLine();
        }
    }
}
