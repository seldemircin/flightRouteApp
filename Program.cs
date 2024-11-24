using System;
using System.Runtime.InteropServices;

namespace linkedlListExample
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Ucus head = null;
            Ucus tail = null;
            
            Yolcu[] yolcular = new Yolcu[2];
            yolcular[0] = new Yolcu { name = "Selahattin" , surname = "Demirçin",koltukNo = 1};
            yolcular[1] = new Yolcu { name = "Alper", surname = "Ateş" , koltukNo = 2};

            void UcusEkle(string nereden,string nereye,int ucusNo,Yolcu[] yolcus)
            {
                if (head != null)
                {
                    Ucus ucus = new Ucus();
                    ucus.ucusNo = ucusNo;
                    ucus.rota = new Rota
                    {
                        baslangic = new Sehir
                        {
                            name  = nereden,next = new Sehir
                            {
                                name = nereye
                            }
                        },yolcular = yolcus
                    };

                    tail.next = ucus;
                    ucus.prev = tail;

                    tail = ucus;
                }
                else
                {
                    Ucus ucus = new Ucus();
                    ucus.ucusNo = ucusNo;
                    ucus.rota = new Rota
                    {
                        baslangic = new Sehir
                        {
                            name  = nereden,next = new Sehir
                            {
                                name = nereye
                            }
                        },yolcular = yolcus
                    };

                    head = ucus;
                    tail = ucus;
                }
            }
            void UcusAra(int ucusNo)
            {
                Ucus index = head;
                bool bulunduMu = false;
                while (index != null)
                {
                    if (index.ucusNo == ucusNo)
                    {
                        Console.WriteLine("Uçuş "+index.rota.baslangic.name+" - "+index.rota.baslangic.next.name+ " yönündedir.");
                        bulunduMu = true;
                        break;
                    }
                    index = index.next;
                }

                if (bulunduMu == false)
                {
                    Console.WriteLine("Aradığınız uçuş bulunamadı.");
                }
            }
            
            UcusEkle("Ankara","İstanbul",10,yolcular);
            UcusEkle("İzmir","Muğla",20,yolcular);
            UcusEkle("Antalya","Erzurum",30,yolcular);
            UcusEkle("Batman","Trabzon",40,yolcular);
            UcusEkle("Konya","Adana",50,yolcular);

            UcusAra(40);
        }
    }

    class Ucus
    {
        public int ucusNo { get; set; }
        public Ucus next { get; set; }
        public Ucus prev { get; set; }
        public Rota rota { get; set; }
    }

    class Rota
    {
        public Yolcu[] yolcular { get; set; }
        public Sehir baslangic { get; set; }
    }

    class Yolcu
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int koltukNo { get; set; }
    }

    class Sehir
    {
        public string name { get; set; }
        public Sehir next { get; set; }
    }
}