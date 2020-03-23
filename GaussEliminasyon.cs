using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
//////////////////// Onur Akbal Tarafindan kodlanmistir. ////////////////////
*/
namespace GaussEliminasyonOnurAkbal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Matrisin Boyutunu Giriniz (NxN) : ");
            int arraylenght = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            double[,] array = new double[arraylenght, arraylenght];
            double[] value = new double[arraylenght];

            for (int i = 0; i < arraylenght; i++)
            {
                for (int j = 0; j < arraylenght; j++)
                {
                    Console.Write((i + 1) + "satir" + (j + 1) + ".sutundaki elemani giriniz: ");
                    array[i, j] = Convert.ToDouble(Console.ReadLine());

                }
            }

            for (int i = 0; i < arraylenght; i++)
            {
                Console.Write("Matrisin " + (i + 1) + ".degeri giriniz : ");
                value[i] = Convert.ToDouble(Console.ReadLine());
            }

            GaussEliminasyon(array, value, arraylenght);
            Console.ReadLine(); //bekletmek icin

        }
        
        static void GaussEliminasyon(double[,] a, double[] b, int boyut)
        {
           for (int k=0; k<(boyut-1); k++)
            {
                for(int i=k+1; i<boyut; i++)
                {
                    double [,] m = new double[boyut, boyut];
                    m[i,k] = a[i, k] / a[k, k];

                    for(int j=k+1; j<boyut ; j++ )
                    {
                        a[i, j] = a[i, j] - m[i, k] * a[k, j];
                    }

                    b[i] = b[i] - m[i, k] * b[k];
                }
            }
            if (a[boyut - 1, boyut - 1] == 0)
            {
                if (b[boyut - 1] == 0)
                {
                    Console.WriteLine("Sonsuz cozum vardır!!!");
                }
                else
                {
                    Console.WriteLine("Cozum yoktur!!!");
                }
            }
            else
            {
                double[] x = new double[boyut];
                double toplam = 0;
                x[boyut - 1] = b[boyut - 1] / a[boyut - 1, boyut - 1];
                for (int i = boyut - 2; i >= 0; i--)
                {

                    for (int j = i + 1; j < boyut; j++)
                    {
                        toplam = toplam + (a[i, j] * x[j]);
                    }

                    x[i] = (1 / a[i, i]) * (b[i] - toplam);
                    toplam = 0;
                }
                Console.WriteLine();
                Console.WriteLine("----------------------");
                Console.WriteLine("Cozum Matrisi : ");
                Console.WriteLine("----------------------");
                Console.WriteLine();
                for (int dongu = 0; dongu < boyut; dongu++)
                {
                    Console.WriteLine("[x" + dongu + "] = " + x[dongu]);
                }
            }
        }  

    }
}

