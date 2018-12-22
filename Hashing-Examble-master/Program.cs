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

            Hashtable symbols = new Hashtable();

            // symbols.Add(Key,Vlaue);
            symbols.Add(7, 100000);
              symbols.Add("isim", "Ali can");
              symbols["cinsiyet"] = "Male";
              symbols.Add("yas", 43);
              symbols.Add("bolum", "Bilgisayar Müh.");
            symbols.Remove(7);
            object  value = symbols[7];
          
            Console.WriteLine("Turkçesi: "+value.ToString());
            Console.WriteLine();


           
        }
    }
}