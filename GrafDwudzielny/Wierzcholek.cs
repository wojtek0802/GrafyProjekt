using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafDwudzielny
{
    class Wierzcholek
    {
        List<Wierzcholek> sasiedzi;
        int wartosc;
        bool odwiedzony;
        int kolor = -1;//-1 kolor neutralny

        public List<Wierzcholek> Sasiedzi { get { return sasiedzi; } set { sasiedzi = value; } }
        public int Wartosc { get { return wartosc; } set { wartosc = value; } }
        public bool Odwiedzony { get { return odwiedzony; } set { odwiedzony = value; } }
        public int IleSasiadow { get { return sasiedzi.Count; } }
        public int Kolor { get { return kolor; } set { kolor = value; } }

        public Wierzcholek(int wartosc, List<Wierzcholek>sasiedzi)
        {
            this.wartosc = wartosc;
            odwiedzony = false;
            this.sasiedzi = sasiedzi;
        }

        public Wierzcholek(int wartosc)
        {
            this.wartosc = wartosc;
            odwiedzony = false;
            sasiedzi = new List<Wierzcholek>();
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
        }

    }
}
