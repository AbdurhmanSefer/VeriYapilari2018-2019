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
            Stack dizi = new Stack();
            Console.WriteLine("İfade giriniz");

            string ifade = Console.ReadLine();

            for(int i=0;i<ifade.Length;i++)
            {
                dizi.Push(ifade[i]);
            }
            bool durum = true;

            for (int i = 0; i < ifade.Length; i++)
            {
                var  temp = dizi.Pop();
               if(ifade[i].ToString()!=temp.ToString())
                {
                    durum = false;
                }
            }


            Console.WriteLine(durum);
            Console.ReadLine();
        }
    }
}