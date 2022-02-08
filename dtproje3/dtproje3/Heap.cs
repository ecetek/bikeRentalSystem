using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dtproje3
{
    class Node
    {
        private Durak durak1; //durak nesnelerinden oluşan düğüm
        public Node(Durak durak1) // constructor

        {
            this.durak1=durak1;
        }

        public Durak getKey()
        {
            return durak1;
        }

        public void setKey(Durak durak1)
        {
            this.durak1=durak1;
        }

    }
    class Heap
    {
        private Node[] heapArray;//durak nesnelerini normal bisiklet sayılarına göre tutacağım
        private int maxSize; 
        private int currentSize;
        public Heap(int mx) // constructor
        {
            maxSize = mx;
            currentSize = 0;
            heapArray = new Node[maxSize]; 
        }

        public bool isEmpty()
        {
            return currentSize == 0;
        }

        public bool insert(Durak durak)
        {
            if (currentSize == maxSize)
                return false;
            Node newNode = new Node(durak);
            heapArray[currentSize] = newNode;
            trickleUp(currentSize++);
            return true;
        }

        public void trickleUp(int index)
        {
            int parent = (index - 1) / 2;//ebeveyn düğüm index
            Node bottom = heapArray[index];
            while (index > 0 && heapArray[parent].getKey().getNormalBisiklet() < bottom.getKey().getNormalBisiklet())//normal bisiklet sayılarını kıyaslıyor
            {
                heapArray[index] = heapArray[parent]; 
                index = parent;
                parent = (parent - 1) / 2;
            } 
            heapArray[index] = bottom;
        }
        public Node remove() 
        { 
            Node root = heapArray[0];
            heapArray[0] = heapArray[--currentSize];
            trickleDown(0);
            return root;
        }

        public void trickleDown(int index)
        {
            int largerChild;
            Node top = heapArray[index]; 
            while (index < currentSize / 2) 
            { 
                int leftChild = 2 * index + 1;
                int rightChild = leftChild + 1;
                
                if (rightChild < currentSize && heapArray[leftChild].getKey().getNormalBisiklet() < heapArray[rightChild].getKey().getNormalBisiklet())
                    largerChild = rightChild;
                else
                    largerChild = leftChild;
                
                if (top.getKey().getNormalBisiklet() >= heapArray[largerChild].getKey().getNormalBisiklet())
                    break;
                
                heapArray[index] = heapArray[largerChild];
                index = largerChild; 
            } 
            heapArray[index] = top; 
            
        }
        public void maxIstasyonBilgi(int n)//en fazla normal bisiklete sahip kaç istasyon sayısını parametre alır
        {
            Console.WriteLine("En fazla normal bisiklet olan "+n+" istasyon ve bilgileri: ");
            for(int i = 0; i < n; i++)//parametre kadar for döngüsü
            {
                Node node = remove();//remove node döndürür,bilgilerini yazdırmak için değişkene atadım
                //ayrıca maxHeap yapısında remove en büyük sayıya göre silmeye başlar
                node.getKey().yazdir();

            }
            
        }

        public void displayHeap()
        {
            Console.WriteLine("heapArray: "); 
            for (int m = 0; m < currentSize; m++)
                if (heapArray[m] != null)//nesne boş olana kadar
                { 
                    heapArray[m].getKey().yazdir();//getkey ile durak nesnesine ulaşıp,yazdır metodunu kullandım
                }

                else
                {
                    Console.WriteLine("-- ");
                }  
                Console.WriteLine();
        }
    }
}