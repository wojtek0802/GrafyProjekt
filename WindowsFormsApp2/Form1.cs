using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GrafDwudzielny;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        int licznik = 1; //licznik wartości wierzchołków
        Graf graf = new Graf(new List<Wierzcholek>());
        
        public Form1()
        {
            DoubleBuffered = true;
            InitializeComponent();
        }
        
        List<Punkty> wspolrzedne = new List<Punkty>(); //Współrzędne dla krawędzi
        Wierzcholek DoDodania1 = null; //zapamiętuje wierzchołek do połączenia
        Wierzcholek DoDodania2 = null; //jw.
        string coRobimy = "Dodaj"; //Opcja kliknięta w toolbarze, na starcie ustawione na dodawanie wierzchołków
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            for (int j = 0; j < wspolrzedne.Count; j++)
                e.Graphics.DrawLine(new Pen(Color.Gray, 1), wspolrzedne[j].X1, wspolrzedne[j].Y1, wspolrzedne[j].X2, wspolrzedne[j].Y2); //rysowanie krawędzi
            for (int j = 0; j < graf.Rozmiar; j++)
            {
                Wierzcholek w = graf.Wspolrzedne(j);
                if (w.Malowanie != Color.Transparent)
                    e.Graphics.FillEllipse(new SolidBrush(w.Malowanie), w.X - 13, w.Y - 13, 26, 26);
                else
                    e.Graphics.DrawEllipse(new Pen(Color.Black, 2), w.X - 13, w.Y - 13, 26, 26); //rysowanie wierzchołków
                if (w.Wartosc <= 9) // rysowanie środka wierzchołka, tzn jego wartości < 10 ;)
                    e.Graphics.DrawString(Convert.ToString(w.Wartosc), new Font(FontFamily.GenericSansSerif, FontHeight, FontStyle.Regular), new SolidBrush(Color.Black), Point.Round(new Point(w.X +-7, w.Y -9)));
                else // rysowanie środka wierzchołka, tzn jego wartości >=10 ;)
                    e.Graphics.DrawString(Convert.ToString(w.Wartosc), new Font(FontFamily.GenericSansSerif, FontHeight, FontStyle.Regular), new SolidBrush(Color.Black), Point.Round(new Point(w.X-13, w.Y -9)));
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (coRobimy == "Dodaj") // sprawdza jaka opcja w toolbarze została kliknięta
            {
                if (graf.CzyMożna(e.Location.X, e.Location.Y) == null)
                {        
                    graf.DodajWierzcholek(new Wierzcholek(licznik, e.Location.X, e.Location.Y)); //Dodaje wierzchołek do grafu
                    licznik++;
                }
            }
            else if (coRobimy == "Łączymy") // Dodawanie krawędzi
            {
                Wierzcholek aktualny = graf.CzyToTen(e.Location.X, e.Location.Y); // sprawdza czy miejscie w które kliknęliśmy zawiera wierzchołek
                if (aktualny != null) // jest null jak kliknęliśmy w inne pole niż wierzchołek
                {
                    graf.UsunWierzcholek(aktualny);
                    aktualny.Malowanie = Color.Red;
                    graf.DodajWierzcholek(aktualny);
                    if (DoDodania1 == null)
                    {
                        DoDodania1 = aktualny;
                    }
                    else
                    {
                        DoDodania2 = aktualny;
                    }
                }
                if (DoDodania1 != null && DoDodania2 != null) //Łączenie krawędzi
                {
                    wspolrzedne.Add(new Punkty(DoDodania1.X, DoDodania1.Y, DoDodania2.X, DoDodania2.Y));
                    graf.UsunWierzcholek(DoDodania1);
                    graf.UsunWierzcholek(DoDodania2);
                    DoDodania1.DodajKrawedz(DoDodania2);
                    DoDodania1.Malowanie = Color.Transparent;
                    DoDodania2.Malowanie = Color.Transparent;
                    graf.DodajWierzcholek(DoDodania2);
                    graf.DodajWierzcholek(DoDodania1);
                    DoDodania1 = null;
                    DoDodania2 = null;
                }
            }
            else if (coRobimy == "Usuwamy") // Usuwanie, powinno już działać ok
            {
                Wierzcholek aktualny = graf.CzyToTen(e.Location.X, e.Location.Y);//Czy kliknęliśmy w graf
                if(aktualny!=null)
                {
                    for (int j = 0; j < graf.Rozmiar; j++)
                    {
                        Wierzcholek w = graf.Wspolrzedne(j);
                        if (aktualny.X - w.X == 0 && aktualny.Y - w.Y == 0)//szukam tego wierzchołka w tablicy od rysowania i go usuwam
                        {
                            graf.UsunWierzcholek(w);
                            graf.Sortuj();
                            int zmiany = 0;
                            for (int i = 0; i < graf.Rozmiar-zmiany; i++)
                            {
                                Wierzcholek w2 = graf.Wspolrzedne(i);
                                if (w2.Wartosc > w.Wartosc)
                                {
                                    graf.UsunWierzcholek(w2);
                                    w2.Wartosc = w2.Wartosc - 1;
                                    graf.DodajWierzcholek(w2);
                                    zmiany++;
                                    i--;
                                }
                            }
                            licznik--;
                            break;
                        }
                    }
                    for (int j = 0; j < wspolrzedne.Count; j++) //szukam krawędzi w tablicy od rysowania i usuwam je, żeby się więcej nie rysowały
                    {
                        if((aktualny.X == wspolrzedne[j].X1 && aktualny.Y ==wspolrzedne[j].Y1) || (aktualny.X == wspolrzedne[j].X2 && aktualny.Y == wspolrzedne[j].Y2))
                        {
                            wspolrzedne.Remove(wspolrzedne[j]);
                            j--;//cofnięcie iteracji,  bo po usunięciu następny z listy wskakuje na miejsce wcześniej i trzeba ponownie sprawdzić
                        }
                    }
                    while(aktualny.IleSasiadow>0)
                    {
                        Wierzcholek chwilowy = aktualny.Sasiedzi[0]; //przypisuje sasiada z 0 pozycji
                        //biorę ciągle sąsiada na pozycji 0, bo po usunięciu krawędzi, sąsiad z wierzchołka chwilowy
                        //już nie będzie sąsiadem i cała lista się przesunie o jeden w dół
                        graf.UsunWierzcholek(chwilowy); // usuwam go z grafu, żeby go dodać potem bez krawędzi którą mamy usunąć
                        chwilowy.UsunKrawedz(aktualny);//usuwam krawędź
                        graf.DodajWierzcholek(chwilowy);//dodaje zupdatowany wierzchołek
                    }
                }
            }
            this.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e) //rysowanie od nowa aplikacji po sprawdzeniu
        {
            bool odp = graf.BFS(graf.Wspolrzedne(0));
            if (odp)
                MessageBox.Show("Graf jest dwudzielny");
            else
                MessageBox.Show("Graf nie jest dwudzielny");// jak tak to wysyłam go jako startowy i sprawdzam
            coRobimy = "Nic";
            this.Invalidate();
        }

        private void DodajWierzcholek_Click(object sender, EventArgs e)
        {
            coRobimy = "Dodaj";
                graf.CzyscGraf();
        }

        private void LaczymyWierzcholki_Click(object sender, EventArgs e)
        {
            coRobimy = "Łączymy";
                graf.CzyscGraf();
        }

        private void UsuwanieWierzcholka_Click(object sender, EventArgs e)
        {
            coRobimy = "Usuwamy";
                graf.CzyscGraf();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Wyczyszczenie();
        }

        private void Wyczyszczenie()
        {
            graf.Restartuj();
            wspolrzedne.Clear();
            licznik = 1;
            DoDodania1 = null;
            DoDodania2 = null;
            coRobimy = "Dodaj";
            this.Invalidate();
        }

    }
}
