using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;

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

        public void Sortuj()
        {
            wierzcholki.Sort();
        }

        public Graf(List<Wierzcholek> wierzcholki)
        {
            this.wierzcholki = wierzcholki;
            rozmiar = wierzcholki.Count;
        }

        public Wierzcholek CzyToTen(int x, int y)
        {
            for (int i = 0; i < rozmiar; i++)
            {
                if (Math.Abs(wierzcholki[i].X - x) <= 13 && Math.Abs(wierzcholki[i].Y-y) <= 13)
                    return wierzcholki[i];
            }
            return null;
        }

        public Wierzcholek CzyMożna(int x, int y)
        {
            for (int i = 0; i < rozmiar; i++)
            {
                if (Math.Abs(wierzcholki[i].X - x) <= 26 && Math.Abs(wierzcholki[i].Y - y) <= 26)
                    return wierzcholki[i];
            }
            return null;
        }

        public void DodajWierzcholek(Wierzcholek wierzcholek)
        {
            wierzcholki.Add(wierzcholek);
            rozmiar = wierzcholki.Count;
        }

        public void CzyscGraf()
        {
            for (int j = 0; j < wierzcholki.Count; j++)
            {
                wierzcholki[j].Malowanie = Color.Transparent;
                wierzcholki[j].Odwiedzony = false;
            }
        }

        public void Restartuj()
        {
            while(wierzcholki.Count>0)
            {
                UsunWierzcholek(wierzcholki[0]);
            }
            rozmiar = 0;
        }

        public void UsunWierzcholek(Wierzcholek wierzcholek)
        {
            wierzcholki.Remove(wierzcholek);
            rozmiar = wierzcholki.Count;
        }

        public bool CzyZawieraWierzcholek(Wierzcholek wierzcholek)
        {
            return wierzcholki.Contains(wierzcholek);
        }

        public Wierzcholek Wspolrzedne(int j)
        {
            return wierzcholki[j];
        }

        public bool BFS(Wierzcholek startowy)
        {
            Queue<Wierzcholek> kolejka = new Queue<Wierzcholek>();
            startowy.Odwiedz();
            startowy.Malowanie = Color.LightGreen;
            kolejka.Enqueue(startowy);
            bool odp = true;
            Wierzcholek aktualny;
            while (kolejka.Count > 0)
            {
                aktualny = kolejka.Dequeue();
                foreach (Wierzcholek sasiad in aktualny.Sasiedzi)
                {
                    if(aktualny.Malowanie == Color.LightGreen)
                    {
                        if (sasiad.Malowanie == Color.LightBlue || sasiad.Malowanie == Color.Transparent)
                            sasiad.Malowanie = Color.LightBlue;
                        else
                        {
                            odp = false;
                            break;
                        }
                    }
                    else
                    {
                        if (sasiad.Malowanie == Color.LightGreen || sasiad.Malowanie == Color.Transparent)
                            sasiad.Malowanie = Color.LightGreen;
                        else
                        {
                            odp = false;
                            break;
                        }
                    }
                    if (!sasiad.Odwiedzony)
                    {
                        sasiad.Odwiedz();
                        kolejka.Enqueue(sasiad);                   
                    }
                }
            }
            
            for (int i = 0; i < rozmiar; i++)
            {
                if(odp==true)
                {
                    if (!wierzcholki[i].Odwiedzony)
                        odp = BFS(wierzcholki[i]);
                }
                else
                {
                    if (!wierzcholki[i].Odwiedzony)
                        BFS(wierzcholki[i]);
                }
            }
            return odp;
        }
    }
}