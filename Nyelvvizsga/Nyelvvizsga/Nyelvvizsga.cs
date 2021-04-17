using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Nyelvvizsga
{
    class Nyelvvizsga
    {
        static List<Sikeresvizsga> sikeres = new List<Sikeresvizsga>();
        static List<Sikertelenvizsga> sikertelen = new List<Sikertelenvizsga>();
        static int evszamlalo=0;
        static void Main(string[] args)
        {
            Console.WriteLine("1.feladat:sikertelen és sikeres csv beolvasása");
            Beolvas1("sikeres.csv");
            Beolvas2("sikertelen.csv");
            Console.WriteLine("\n2.feladat:A legnépszerűbb nyelvek:");
            int osszessikeres = 0;
            int osszessikertelen = 0;
            int osszeg = 0;
            foreach (Sikeresvizsga item in sikeres)
            {
                osszessikeres += item.Ev9 + item.Ev10 + item.Ev11+item.Ev12+item.Ev13+item.Ev14+item.Ev15+item.Ev16+item.Ev17+item.Ev18;
                Console.WriteLine(item.Nyelv+osszessikeres);
            }
            foreach (Sikertelenvizsga item in sikertelen)
            {
                osszessikertelen += item.Ev9 + item.Ev10+item.Ev11+item.Ev12+item.Ev13+item.Ev14+item.Ev15+item.Ev16+item.Ev17+item.Ev918;
                Console.WriteLine("\n"+item.Nyelv+osszessikertelen);
            }
            osszeg = osszessikeres + osszessikertelen;
            Dictionary<string, int> nyelveksikeres = new Dictionary<string, int>();
            foreach (Sikeresvizsga item in sikeres)
            {
                if (nyelveksikeres.ContainsKey(item.Nyelv))
                {
                   
                }
                else
                {
                    nyelveksikeres.Add(item.Nyelv, osszessikeres);
                }
            }
            Dictionary<string,int> nyelveksikertelen = new Dictionary<string, int>();
            foreach (Sikertelenvizsga item in sikertelen)
            {
                if (nyelveksikertelen.ContainsKey(item.Nyelv))
                {

                }
                else
                {
                    nyelveksikertelen.Add(item.Nyelv, osszessikertelen);
                }
            }
            var legnepszerubb=nyelveksikertelen.OrderByDescending(a => a.Key).Take(3);
            var legnepszerubb2 = nyelveksikeres.OrderByDescending(b => b.Key).Take(3);
            foreach (var item in legnepszerubb)
            {
                Console.WriteLine(item.Key);
            }
            foreach (var item in legnepszerubb2)
            {
                Console.WriteLine(item.Key);
            }
            Console.WriteLine("\n3.feladat:");
            int evszam;
            do
            {
                Console.Write("Vizsgálandó év:");
                 evszam = int.Parse(Console.ReadLine());
            } while (evszam<2009 && evszam>=2017);
            Console.WriteLine("\n4.feladat:");
            double maxarany = 0;
            double aranysikeres = 0;
            double aranysikertelen = 0;
            foreach (Sikeresvizsga item in sikeres)
            {
                aranysikeres = osszeg + osszessikeres / evszamlalo;
                Console.WriteLine(item.Nyelv+aranysikeres);
            }
            foreach (Sikertelenvizsga item in sikertelen)
            {
                aranysikertelen = osszessikertelen + osszeg / evszamlalo;
                if (evszam==2009 || evszam==2010 || evszam==2011 || evszam==2012 || evszam==2013 || evszam==2014 || evszam==2015 || evszam==2016 || evszam==2017 || evszam==2018 && aranysikertelen>maxarany)
                {
                    maxarany = aranysikertelen;
                    Console.WriteLine($"{evszam}-ben{item.Nyelv} nyelvből a sikertelen vizsgázók aránya:{maxarany}%");
                }
                
            }
            
            Console.WriteLine("\n5.feladat:");
            bool vannyelv = false;
            foreach (Sikertelenvizsga item in sikertelen)
            {
                if (evszam==2009 || evszam==2010 || evszam==2011 || evszam==2012 || evszam==2013 || evszam==2014 || evszam==2015 || evszam==2016 || evszam==2017 || evszam==2018)
                {
                    if (item.Ev9==0 ||  item.Ev10==0 || item.Ev11==0 || item.Ev12==0 || item.Ev13==0 || item.Ev14==0 || item.Ev15==0 || item.Ev16==0 || item.Ev17==0 || item.Ev918==0)
                    {
                        vannyelv = true;
                        Console.WriteLine(item.Nyelv);
                        break;
                    }
                }
            }
            if (!vannyelv)
            {
                Console.WriteLine("Minden nyelvből volt vizsgázó!");
            }
            Console.WriteLine("\n6.feladat:");
            Dictionary<string, double> SikeresAranyszotar = new Dictionary<string, double>();
            foreach (Sikeresvizsga item in sikeres)
            {
                if (SikeresAranyszotar.ContainsKey(item.Nyelv))
                {

                }
                else
                {
                    SikeresAranyszotar.Add(item.Nyelv, aranysikeres);
                }

            }
            foreach (var item in SikeresAranyszotar)
            {
                Console.WriteLine(item.Key,item.Value);
            }
            using (StreamWriter iras=new StreamWriter("osszesites.csv",false,Encoding.Default))
            {
                foreach (Sikeresvizsga item in sikeres)
                {
                    iras.WriteLine($"{item.Nyelv};{osszessikeres};{aranysikeres}");
                }
                iras.Close();
            }
            Console.WriteLine("\nProgram Vége!");
            Console.ReadLine();
        }
        static void Beolvas1(string filenev)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filenev,Encoding.Default))
                {
                    string fejlec = sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        evszamlalo++;
                        sikeres.Add(new Sikeresvizsga(sr.ReadLine()));
                    }
                    sr.Close();
                }
            }
            catch (IOException ioex)
            {
                Console.WriteLine(ioex.Message);
                Console.ReadKey();
                Environment.Exit(0);
            }
            
        }
        static void Beolvas2(string filenev)
        {
            try
            {
                using (StreamReader sr2=new StreamReader(filenev,Encoding.Default))
                {
                    string fejlec = sr2.ReadLine();
                    while (!sr2.EndOfStream)
                    {
                        evszamlalo++;
                        sikertelen.Add(new Sikertelenvizsga(sr2.ReadLine()));
                    }
                    sr2.Close();
                }
            }
            catch (IOException ioex)
            {
                Console.WriteLine(ioex.Message);
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
    }
}
