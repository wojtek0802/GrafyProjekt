using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GrafDwudzielny
{
    class Graf
    {
        List<Wierzcholek> wierzcholki;
        int rozmiar; //ilosc wierzcholkow
        
        public int Rozmiar { get { return wierzcholki.Count; } }

        public Graf()
        {
            wierzcholki = new List<Wierzcholek>();
            rozmiar = 0;
        }

        public Graf(List<Wierzcholek> wierzcholki)
        {
            this.wierzcholki = wierzcholki;
            rozmiar = wierzcholki.Count;
        }

        public void DodajWierzcholek(Wierzcholek wierzcholek)
        {
            rozmiar++;
            wierzcholki.Add(wierzcholek);
        }

        public void UsunWierzcholek(Wierzcholek wierzcholek)
        {
            rozmiar--;
            wierzcholki.Remove(wierzcholek);
        }

        public bool CzyZawieraWierzcholek(Wierzcholek wierzcholek)
        {
            return wierzcholki.Contains(wierzcholek);
        }

        public void BFS(Wierzcholek startowy)
        {
            Queue<Wierzcholek> kolejka = new Queue<Wierzcholek>();
            startowy.Odwiedz();
            kolejka.Enqueue(startowy);

            Console.WriteLine(startowy.Wartosc + " ");
            Wierzcholek aktualny;
            while (kolejka.Count > 0)
            {
                aktualny = kolejka.Dequeue();
                foreach (Wierzcholek sasiad in aktualny.Sasiedzi)
                {
                    if (!sasiad.Odwiedzony)
                    {
                        Console.WriteLine(sasiad.Wartosc + " ");
                        sasiad.Odwiedz();
                        kolejka.Enqueue(sasiad);                   
                    }
                }
            }
            for (int i = 0; i < rozmiar; i++)
            {
                if(!wierzcholki[i].Odwiedzony)
                {
                    BFS(wierzcholki[i]);
                }
            }
        }

    }
}