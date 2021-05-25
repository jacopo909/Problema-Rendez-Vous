using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Problema_Rendez_Vous
{
    class Program
    {
        static SemaphoreSlim semaforo = new SemaphoreSlim(1);
        static int[] V = new int[1000];
        static int[] W = new int[1000];
        static void Main(string[] args)
        {
            Random r1 = new Random();
            Random r2 = new Random();
            for (int i = 0; i < 1000; i++)
            {
                V[i] = r1.Next(0, 1000);
                W[i] = r2.Next(0, 1000);
            }
            Thread t1 = new Thread(() => Metodo1());
            semaforo.Wait(); //1 --> 0
            t1.Start();
            semaforo.Release(); // 0 --> 1
            Thread t2 = new Thread(() => Metodo2());
            semaforo.Wait(); // 1 --> 0        
            t2.Start();

            Console.ReadKey();
        }
        static private async void Metodo1()
        {
            int minimo;
            int temp = 0;
            foreach (int i in V)
            {
               if(V[i] < W[i])
               {
                    temp = V[i];     
                    
               }
               else
               {
                    temp = W[i];
                    
               }
            }
            minimo = temp;
            Console.WriteLine($"il minimo è: {minimo}");
            
        }
        static private async void Metodo2()
        {
            int media;
            int temp = 0;
            for (int i = 0; i < W.Length; i++)
            {
                temp += V[i] + W[i];
                
            }
            media = temp / 2000;
            Console.WriteLine($"la media è: {media}");
        }
    }
}
