using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace GrafDwudzielny
{
    class Wierzcholek : IComparable<Wierzcholek>
    {
        List<Wierzcholek> sasiedzi;
        int wartosc;
        bool odwiedzony;
        Color malowanie = Color.Transparent;
        int x; // wspolrzedne wierzcholka
        int y; // wpolrzedne wierzcholka

        public List<Wierzcholek> Sasiedzi { get { return sasiedzi; } set { sasiedzi = value; } }
        public int Wartosc { get { return wartosc; } set { wartosc = value; } }
        public bool Odwiedzony { get { return odwiedzony; } set { odwiedzony = value; } }
        public int IleSasiadow { get { return sasiedzi.Count; } }
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public Color Malowanie { get { return malowanie; } set { malowanie = value; } }

        public Wierzcholek(int wartosc, List<Wierzcholek>sasiedzi)
        {
            this.wartosc = wartosc;
            odwiedzony = false;
            this.sasiedzi = sasiedzi;
        }

        public Wierzcholek(int wartosc, int x, int y)
        {
            this.wartosc = wartosc;
            odwiedzony = false;
            this.x = x;
            this.y = y;
            sasiedzi = new List<Wierzcholek>();
        }

        public int CompareTo(Wierzcholek wierzcholek)
        {
            return wartosc.CompareTo(wierzcholek.wartosc);
        }

        public void Odwiedz()
        {
            odwiedzony = true;
        }

        public void DodajKrawedz(Wierzcholek wierzcholek)
        {
            sasiedzi.Add(wierzcholek);
            wierzcholek.sasiedzi.Add(this);
        }

        public void UsunKrawedz(Wierzcholek wierzcholek)
        {
            sasiedzi.Remove(wierzcholek);
            wierzcholek.sasiedzi.Remove(this);
        }

    }
}
