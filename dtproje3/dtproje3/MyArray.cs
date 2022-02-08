using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dtproje3
{
    class MyArray
    {
        int[] sayilar;
        int elemanSayisi;
        MyArray myArray ;
        MyArray myArray1;
        int turQuickSort = 0;
        public MyArray(int max)//dizinin boyutu parametre olarak alınır
        {
            sayilar = new int[max];
            elemanSayisi = 0;

        }

        private void ekle(int deger)
        {
            sayilar[elemanSayisi] = deger;
            elemanSayisi++;
        }
        private void yazdir()
        {
            for (int i = 0; i < elemanSayisi; i++)
            {
                Console.Write(sayilar[i] + " ");
            }
            Console.ReadLine();
        }


        private void selectionSort()
        {
            int min;
            int kıyaslama = 0;
            for (int i = 0; i < elemanSayisi ; i++)//0.indexi en küçük eleman kabul eder 
            {
                min = i;
                for (int j = i + 1; j < elemanSayisi; j++)//tüm elemanlarla kıyaslar
                {
                     
                    if (sayilar[j] < sayilar[min])
                    {
                       swap(i, min);//eğer en küçük varsadığımız elemandan daha küçük değer varsa yerleri değiştirilir
                        
                    }
                    kıyaslama++;
                }
            }Console.WriteLine("Zaman Karmaşıklığı : " + kıyaslama );
        }


        private void swap(int sayi1, int sayi2)
        {
            int temp = sayilar[sayi1];
            sayilar[sayi1] = sayilar[sayi2];
            sayilar[sayi2] = temp;
        }

        private void quickSort()
        {   
            recQuickSort(0, elemanSayisi - 1);
            Console.WriteLine("Zaman Karmaşıklığı : "+ turQuickSort);
        }
        private void recQuickSort(int left, int right)
        {
            
            if (right - left <= 0)//eleman kalmayana kadar parçalama işlemi devam eder
                return;
            else
            {
                int pivot = sayilar[right];//dizinin son elemanı pivot seçildi
                int partition = partitionIt(left, right, pivot);
                recQuickSort(left, partition - 1);//pivot değerden küçükler solunda sıralanır
                recQuickSort(partition + 1, right);//büyükler sağında sıralanır
            }
        }
        private int partitionIt(int left, int right,int pivot)
        {
            
            int leftPtr = left - 1;//baş
            int rightPtr = right;//son
            while (true)
            {
                while (sayilar[++leftPtr] < pivot) ;//kıyaslama
                while (rightPtr > 0 && sayilar[--rightPtr] > pivot) ;
                    turQuickSort++;
                if (leftPtr >= rightPtr)
                    break;
                else
                    swap(leftPtr, rightPtr);//büyük ile küçük sayının yerini değiştiriyor
                    
            } 
            
            swap(leftPtr, right);//pivot değerden küçükler solda,büyükler sağda tutuluyor
            return leftPtr;
        }
        private void sayiDizisiOlustur()
        {
            Random r = new Random();
            int maxSize = sayilar.Length;
            myArray = new MyArray(maxSize);
            myArray1 = new MyArray(maxSize);

            for (int i = 0; i < maxSize; i++)
            {
                int sayi = r.Next(0, 100);//random sayılar oluşturulur
                int sayi1 = r.Next(0, 100);
                myArray.ekle(sayi);
                myArray1.ekle(sayi1);

            }
        }
        public void arrayBilgiYazdir()
        {
            sayiDizisiOlustur();
            Console.WriteLine("Sıralamadan önce :");
            myArray.yazdir();
            myArray.selectionSort();
            Console.WriteLine("Selection Short sıralaması sonrası :");
            myArray.yazdir();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Sıralamadan önce :");
            myArray1.yazdir();
            myArray1.quickSort();
            Console.WriteLine("Quick  Short sıralaması sonrası  :");
            myArray1.yazdir();
        }
    }
}
