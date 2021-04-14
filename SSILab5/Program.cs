using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace SSILab5
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] jeden = new double[] { 4, 3, 1, 0 };

            int k = 10;

            var x= PorownajDlugosci(jeden, Wczytaj(),k);
            Glosowanie(x);
            Console.ReadKey();

        }
        static double ObliczOdleglosc(double[] tab1, double[]tab2)
        {
            double z = 0.0;
            for (int i = 0; i < tab1.Length; i++)
            {
                z += Math.Pow((tab1[i] - tab2[i]), 2);
            }
            double x = Math.Sqrt(z);
            
            return x;
        }
       
        static string[] PorownajDlugosci(double[] tab, double[][] tab2, int k)
        {
            string[] lines = File.ReadAllLines(@"baza.txt");

            double[] dlugosc = new double[lines.Length] ;
            string[] kwiatek = new string[k];
            int[] indeks = new int[lines.Length];
            int[] wynik = new int[k];

            for (int i = 0; i < lines.Length; i++)
            {
                var temp = tab2[i];
                
                double x = ObliczOdleglosc(tab, temp);
                dlugosc[i] = x;
                indeks[i] = i;
            }

            Array.Sort(dlugosc, indeks);

            for (int i = 0; i < k; i++)
            {
                int x = indeks[i];
                kwiatek[i] = (tab2[x][4] + "" + tab2[x][5] + "" + tab2[x][6]);
            }
            return kwiatek;

          
        }
        public static void Glosowanie(string[] tab)
        {

            var klasa1 = "100";
            var klasa2 = "010";
            var klasa3 = "001";


            int maxL = 0;
            string maxW = tab[0];

            for (int i = 0; i < tab.Length; i++)
            {
                string W = tab[i];
                int licznik = 0;

                for (int j = 0; j < tab.Length; j++)
                {
                    if (tab[j] == W)
                    {
                        licznik++;


                        if (licznik > maxL)
                        {
                            maxL = licznik;
                            maxW = W;
                        }
                    }
                }
            }
            
            if (maxW == klasa1)
                Console.WriteLine("Iris-virginica");
            else if (maxW == klasa2)
                Console.WriteLine("Iris-versicolor");
            else if (maxW ==klasa3)
                Console.WriteLine("Iris-setosa");

        }
        


        static double[][] Wczytaj()
        {
            string kwiat1 = "Iris-setosa";
            string kwiat2 = "Iris-versicolor";
            string kwiat3 = "Iris-virginica";


            string[] lines = File.ReadAllLines(@"baza.txt");
            double[][] dane = new double[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] tmp = lines[i].Split(',');
                dane[i] = new double[tmp.Length + 2];
                for (int j = 0; j < tmp.Length; j++)
                {
                    try
                    {
                        dane[i][j] = Convert.ToDouble(tmp[j]);
                    }
                    catch
                    {
                        if (String.Equals(tmp[j], kwiat1))
                        {
                            dane[i][4] = 0;
                            dane[i][5] = 0;
                            dane[i][6] = 1;
                        }
                        else if (String.Equals(tmp[j], kwiat2))
                        {
                            dane[i][4] = 0;
                            dane[i][5] = 1;
                            dane[i][6] = 0;
                        }
                        else if (String.Equals(tmp[j], kwiat3))
                        {
                            dane[i][4] = 1;
                            dane[i][5] = 0;
                            dane[i][6] = 0;
                        }

                    }
                }
            }
            return dane;
        }
    }
}
