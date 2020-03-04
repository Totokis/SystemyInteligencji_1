using System;
using System.IO;


namespace Irirs
{

    class Program
    {

        static public double Normalizacja(double x, double max, double min, double nmax = 1.0, double nmin = 0.0)
        {
            x = (x - min) * (nmax - nmin) / (max - min) + nmin;
            return x;
        }
        static void Shuffle(double[][]array)
        {
            Random rnd = new Random();
            int n = array.Length;
            for (int i = 0; i < (n-1); i++)
            {
                int r = i + rnd.Next(n - i);
                double[] t = array[r];
                array[r] = array[i];
                array[i] = t;
            }
        }
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"iris.txt");// zwraca tablicę o
            //długości równej ilości wierszy w pliku tekstowym
            //Console.WriteLine("Hello World!");

            double[][] data = new double[lines.Length][];//stworzenie tablicy tablic od długości równej długości tablicy wierszy
            double[] normalizedData = new double[lines.Length];//
            for (int i = 0; i < lines.Length; i++)//
            {
                string[] tmp = lines[i].Split(",");//funkcja split zwraca tablicę,
                //Console.WriteLine(tmp);
                data[i] = new double[tmp.Length+2];//tworzymy w każdym wierszu tablicy tablicę o długości o dwa dłuższej niż długość pierwotna, ponieważ będziemy kodować
                //każdą nazwę za pomocą trzech liczb
                for (int j = 0; j < tmp.Length - 1; j++)
                {
                    //Console.WriteLine(tmp[j]);
                    data[i][j] = Convert.ToDouble(tmp[j].Replace(".", ","));//konwersja danych na typ double, oprócz tego zamiana kropek na przecinki
                    //( w notacji polskiej używa się przecinków do liczb zmiennoprzecinkowych, a nie kropek
                    //Console.WriteLine(data[i][j]);
                }
                if(tmp[4] == "Iris-setosa")//konwersja nazw na liczby;
                {
                    data[i][4] = 0;
                    data[i][5] = 0;
                    data[i][6] = 1;
                }
                else if (tmp[4] == "Iris-versicolor")
                {
                    data[i][4] = 0;
                    data[i][5] = 1;
                    data[i][6] = 0;
                }
                else if (tmp[4] == "Iris-virginica")
                {
                    data[i][4] = 1;
                    data[i][5] = 0;
                    data[i][6] = 0;
                }
            }
            //Console.WriteLine(data[1][1]);
            for ( int k = 0; k < 4; k++)//k jak kolumny
            {
                double min = data[0][k];
                double max = data[0][k];
                for (int w = 0; w < data.Length; w++)//w jak wiersze; szukamy min i max
                {
                    //Console.WriteLine(data[w][k]);
                    if (data[w][k] > max)
                    {
                        //Console.WriteLine(data[w][k]);
                        max = data[w][k];
                    }
                        if(data[w][k] < min)
                    {
                        min = data[w][k];
                    }
                }
                Console.WriteLine("Min = " + min + ", max = " + max);
                for (int w = 0; w < data.Length; w++)//w jak wiersze; normalizujemy
                {
                    data[w][k] = Normalizacja(data[w][k], max, min);
                }
            }
            //foreach (var item in data)
            //{
            //    Console.WriteLine(item[0] + "|");
            //    Console.Write(item[1] + "|");
            //    Console.Write(item[2] + "|");
            //    Console.Write(item[3] + "|");
            //    Console.Write(item[4]);
            //    Console.Write(item[5]);
            //    Console.Write(item[6]);
            //}
            Shuffle(data);
            foreach (var item in data)
            {
                Console.WriteLine("[0]\t"+item[0] + "|");
                Console.WriteLine("[1]\t" + item[1] + "|");
                Console.WriteLine("[2]\t" + item[2] + "|");
                Console.WriteLine("[3]\t" + item[3] + "|");
                Console.WriteLine("[4]\t" + item[4] + "|");
                Console.WriteLine("[5]\t" + item[5] + "|");
                Console.WriteLine("[6]\t" + item[6] + "|");
                Console.WriteLine("_______________________________________");
            }
        }
    }
}