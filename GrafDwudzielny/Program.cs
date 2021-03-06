﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafDwudzielny
{
    class Program
    {
        static void Main(string[] args)
        {
            Wierzcholek w1 = new Wierzcholek(1);
            Wierzcholek w2 = new Wierzcholek(2);
            Wierzcholek w3 = new Wierzcholek(3);
            Wierzcholek w4 = new Wierzcholek(4);
            Wierzcholek w5 = new Wierzcholek(5);
            Wierzcholek w6 = new Wierzcholek(6);
            Wierzcholek w7 = new Wierzcholek(7);
            Wierzcholek w8 = new Wierzcholek(8);

            w1.DodajKrawedz(w2);
            w1.DodajKrawedz(w7);
            w3.DodajKrawedz(w5);
            w3.DodajKrawedz(w6);
            w4.DodajKrawedz(w5);
            w8.DodajKrawedz(w2);
            w8.DodajKrawedz(w7);

            Graf graf = new Graf(new List<Wierzcholek>() { w1, w2, w3, w4, w5,w6,w7,w8});

            Console.WriteLine(graf.BFS(w1));

            Wierzcholek z1 = new Wierzcholek(1);
            Wierzcholek z2 = new Wierzcholek(2);
            Wierzcholek z3 = new Wierzcholek(3);
            Wierzcholek z4 = new Wierzcholek(4);

            z1.DodajKrawedz(z2);
            z1.DodajKrawedz(z3);
            z2.DodajKrawedz(z4);
            z3.DodajKrawedz(z4);
            z3.DodajKrawedz(z2);

            Graf graf2 = new Graf(new List<Wierzcholek>() { z1,z2,z3,z4});
            Console.WriteLine(graf2.BFS(z1));
            Console.ReadKey();


        }
    }
}
