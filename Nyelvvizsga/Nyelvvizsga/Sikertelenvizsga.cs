using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyelvvizsga
{
    class Sikertelenvizsga
    {
        //nyelv;2009;2010;2011;2012;2013;2014;2015;2016;2017;2018
        private string nyelv;
        private int ev9;
        private int ev10;
        private int ev11;
        private int ev12;
        private int ev13;
        private int ev14;
        private int ev15;
        private int ev16;
        private int ev17;
        private int ev918;

        public string Nyelv { get => nyelv; set => nyelv = value; }
        public int Ev9 { get => ev9; set => ev9 = value; }
        public int Ev10 { get => ev10; set => ev10 = value; }
        public int Ev11 { get => ev11; set => ev11 = value; }
        public int Ev12 { get => ev12; set => ev12 = value; }
        public int Ev13 { get => ev13; set => ev13 = value; }
        public int Ev14 { get => ev14; set => ev14 = value; }
        public int Ev15 { get => ev15; set => ev15 = value; }
        public int Ev16 { get => ev16; set => ev16 = value; }
        public int Ev17 { get => ev17; set => ev17 = value; }
        public int Ev918 { get => ev918; set => ev918 = value; }

        public Sikertelenvizsga(string nyelv, int ev9, int ev10, int ev11, int ev12, int ev13, int ev14, int ev15, int ev16, int ev17, int ev918)
        {
            Nyelv = nyelv;
            Ev9 = ev9;
            Ev10 = ev10;
            Ev11 = ev11;
            Ev12 = ev12;
            Ev13 = ev13;
            Ev14 = ev14;
            Ev15 = ev15;
            Ev16 = ev16;
            Ev17 = ev17;
            Ev918 = ev918;
        }
        public Sikertelenvizsga(string sor)
        {
            string[] adatok = sor.Split(';');
            Nyelv = adatok[0];
            Ev9 = int.Parse(adatok[1]);
            Ev10 = int.Parse(adatok[2]);
            Ev11 = int.Parse(adatok[3]);
            Ev12 = int.Parse(adatok[4]);
            Ev13 = int.Parse(adatok[5]);
            Ev14 = int.Parse(adatok[6]);
            Ev15 = int.Parse(adatok[7]);
            Ev16 = int.Parse(adatok[8]);
            Ev17 = int.Parse(adatok[9]);
            Ev918 = int.Parse(adatok[10]);
        }
    }
}
