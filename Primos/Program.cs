using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Primos
{
    class Program
    {

        public static bool isPrimo(int x)
        {
            int f = x/2 + 1;
            for (int i=2;i<f;++i)
                if (x%i == 0) return false;
            return true;
        }

        public static void procPrimos(int id, int inicio, int fim)
        {
            DateTime hinicio, hfim;
            int k = 0;

            hinicio = DateTime.Now;
            for (int i = inicio; i < fim; ++i)
                if (isPrimo(i)) ++k;
            hfim = DateTime.Now;

            Console.WriteLine("Thread " + id + " encontrou " + k + " numeros primos.");
            Console.WriteLine("Começou em.: " + hinicio.ToString("MM/dd/yyyy hh:mm:ss.fff tt"));
            Console.WriteLine("Terminou em: " + hfim.ToString("MM/dd/yyyy hh:mm:ss.fff tt"));
            Console.WriteLine("Tempo = " + (hfim - hinicio));
        }

        static void Main(string[] args)
        {
            int i, inicio, fim;
            Thread[] mythread = new Thread[100];

            for(i = 0, inicio = 1, fim = 3000; i < 100; ++i, inicio += 3000, fim += 3000)
            {
                mythread[i] = new Thread(() => procPrimos(i, inicio, fim));
                mythread[i].Start();
            }
           
            Console.ReadKey();
        }

    }
}
