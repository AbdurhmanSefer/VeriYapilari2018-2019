using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Tower
{
    class Program
    {
       
        static void Main(string[] args)
        {
          
            Random uretec = new Random();

            Queue queue = new Queue();

            DateTime son = Convert.ToDateTime("17:00:00");

            DateTime basla = Convert.ToDateTime("08:00:00");

            int giren = 0;
            int adet = 1;
            int islem = 0;
            string kisi = "kişi";
            while (basla < son)
            {
                DateTime gececi = basla;
                giren = uretec.Next(1, 15);
                queue.Enqueue(kisi);
                islem = uretec.Next(6, 10);
                queue.Dequeue();
                basla = basla.AddMinutes(islem + giren);
                Console.WriteLine(adet + ". kişinin geliş saati = " + gececi.AddMinutes(giren) + " ve işlem süresi " + islem + " dk " + " çıkış saati =" + basla);
                adet++;
            }
            Console.ReadLine();

           
        }
    }
}