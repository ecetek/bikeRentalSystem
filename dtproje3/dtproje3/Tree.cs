using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dtproje3
{
    class Tree
    {
        static Random s = new Random();
        List<Müsteri> musteriler;
        private TreeNode root;
        public int maxDepth;//iki metodda da kullanacağım için burada oluşturdum
        int musteriSayKopya;//iki metodda da kullanacağım

        public Tree()
        {
            root = null;
        }

        public TreeNode getRoot()
        {
            return root;
        }


        public void postOrderYazdir(TreeNode localRoot)
        {
            if (localRoot != null)//null olana kadar devam ediyor
            {
                postOrderYazdir(localRoot.leftChild);
                postOrderYazdir(localRoot.rightChild);
                localRoot.displayNode();
                //önce sol ağaç,sonra sağ ağaç en son da kök dolaşılır
            }
        }

        public List<Müsteri> randomMusteriOlusturma()
        {
            musteriler = new List<Müsteri>();
            int musteriSayisi = s.Next(1, 10);//random 
            musteriSayKopya = musteriSayisi;//başka metodda parametre olarak kullanacağım için müşteri sayısını saydım
            for (int i = 0; i < musteriSayisi; i++)
            {
                Müsteri musteri = new Müsteri();
                musteriler.Add(musteri);//random sayıda ürettiğim random nesneleri TreeNode içinde bulunan generic list'e ekledim
            }
            return musteriler;
        }


        public void insert(Durak newdata)//ekleme işlemi
        {
            TreeNode newNode = new TreeNode();
            newNode.data = newdata;//parametredeki veriyi atadım
            newNode.musteriler = randomMusteriOlusturma();//random sayıda müşteriyi,düğümün içindeki müşteriler list'ine ekledim
            //bilgileri TreeNode içindeki generic list'e eklendi
            newNode.data.nesneGuncelle(musteriSayKopya, newNode.data);//durak bilgileri güncelleniyor
            if (root == null)
                root = newNode;//ağaç boşsa ağacı dolaşmadan nesneyi ekledi
            else
            {
                TreeNode current = root;//kökten başlar
                TreeNode parent;
                while (true)
                {
                    parent = current;
                    string value1 = newdata.getDurakAdi();
                    string value2 = current.data.getDurakAdi();
                    var result = value1.CompareTo(value2);//kıyaslama işlemi
                    if (result == -1)//eklenecek yeni nesne adı alfabetik olarak daha önceyse
                    {
                        current = current.leftChild;//sol alt dallar kontrol ediliyor
                        if (current == null)
                        {
                            parent.leftChild = newNode;
                            return;//ekleme işlemi oldu,döngü biter
                        }
                    }
                    else//
                    {
                        current = current.rightChild;//sağ alt dallar kontrol ediliyor
                        if (current == null)
                        {
                            parent.rightChild = newNode;//boş olan sağ alt dala eklendi
                            return;
                        }
                    }
                }
            }
        }
        public void kirala(TreeNode root1, string durakAdi, int id)
        {//kullanıcının istediği duraktan,belirlenen id'ye göre kiralama işlemi

            while (root1 != null)
            {
                int result = durakAdi.CompareTo(root1.data.getDurakAdi());
                if (root1.data.getDurakAdi() == durakAdi)
                {

                    Müsteri musteriNesne = root1.data.kiralamaIslemi(root1.data, id);//durak bilgileri güncellendi
                    root1.musteriler.Add(musteriNesne);//kiralama işlemi sonrası oluşturulan nesne ekleniyor
                    root1.istasyonBilgi();
                    Console.WriteLine("Güncel durak bilgileri : ");
                    root1.data.yazdir();
                    return;
                }
                if (result == -1)//alfabetik olarak daha önceyse sağ alt dalı kontrol ediyor
                {
                    root1 = root1.leftChild;
                }
                else
                {//alfabetik olarak daha sonraysa
                    root1 = root1.rightChild;
                }

            }

        }


        public void IdBilgi(TreeNode localRoot1, int Id)//istenilen  id bilgisi
        {

            if (localRoot1 != null)//ağaç içindeki tüm node'ları dolaşıyor
            {

                foreach (Müsteri musteri in localRoot1.musteriler)//Node içindeki müşteriler listesini kontrol ediyor
                {
                    if (musteri.getId() == Id)//istenen id ile müşteri id'si eşlesirse
                    {
                        musteri.yazdir();//müşteri bilgi
                        localRoot1.istasyonBilgi();//istasyon bilgi
                    }

                }
                IdBilgi(localRoot1.leftChild, Id);
                IdBilgi(localRoot1.rightChild, Id);
                //recursive
            }

        }


        private void traverseTreeForInfo(TreeNode node, int depth)
        {
            if (node != null)//boş node olana kadar tüm ağacı dolaşıyor
            {
                depth++;

                if (depth > maxDepth)
                    maxDepth = depth;//daha büyük depth bulursa max değişkeni güncelleniyor


                traverseTreeForInfo(node.leftChild, depth);
                traverseTreeForInfo(node.rightChild, depth);
                //recursive

            }
        }

        public void findAndWriteTreeInfo(TreeNode rootNode)
        {

            traverseTreeForInfo(rootNode, -1);//derinlik bulundu
            Console.WriteLine("\nAğacın derinliği: " + maxDepth);

        }

    }

}
