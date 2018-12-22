using System;
using System.Collections.Generic;
using System.Text;

namespace Tower
{
    class Program
    {
        static int movecount = 0;
        static public void Solve2DiscsTOH(Stack<int> source, Stack<int> temp, Stack<int> dest)
        {
            temp.Push(source.Pop());
            movecount++;
            PrintStacks();
            dest.Push(source.Pop());
            movecount++;
            PrintStacks();
            dest.Push(temp.Pop());
            movecount++;
            PrintStacks();
        }

        static public bool SolveTOH(int nDiscs, Stack<int> source, Stack<int> temp, Stack<int> dest)
        {
            if (nDiscs <= 4)
            {
                if ((nDiscs % 2) == 0)
                {
                    Solve2DiscsTOH(source, temp, dest);
                    nDiscs = nDiscs-1;
                    if (nDiscs == 1)
                        return true;

                    temp.Push(source.Pop());
                    movecount++;
                    PrintStacks();
                    //new source is dest, new temp is source, new dest is temp;
                    Solve2DiscsTOH(dest, source, temp);
                    dest.Push(source.Pop());
                    movecount++;
                    PrintStacks();
                    //new source is temp, new temp is source, new dest is dest;
                    SolveTOH(nDiscs, temp, source, dest);
                }
                else
                {
                    if (nDiscs == 1)
                        return false;
                    Solve2DiscsTOH(source, dest, temp);
                    nDiscs = nDiscs-1;
                    dest.Push(source.Pop());
                    movecount++;
                    PrintStacks();
                    Solve2DiscsTOH(temp, source, dest);
                }
                return true;
            }
            else if (nDiscs >= 5)
            {
                SolveTOH(nDiscs -2, source, temp, dest);
                temp.Push(source.Pop());
                movecount++;
                PrintStacks();
                SolveTOH(nDiscs - 2, dest, source, temp);
                dest.Push(source.Pop());
                movecount++;
                PrintStacks();
                SolveTOH(nDiscs - 1, temp, source, dest);
            }
            /***
            // For your understanding purpose
            if (nDiscs == 5)
            {
            SolveTOH(3, source, temp, dest);
            temp.Push(source.Pop());
            SolveTOH(3, dest, source, temp);
            dest.Push(source.Pop());
            SolveTOH(4, temp, source, dest);
            }
            else if(nDiscs == 6)
            {
            SolveTOH(4, source, temp, dest);
            temp.Push(source.Pop());
            SolveTOH(4, dest, source, temp);
            dest.Push(source.Pop());
            SolveTOH(5, temp, source, dest);
            }
            else if (nDiscs == 7)
            {
            SolveTOH(5, source, temp, dest);
            temp.Push(source.Pop());
            SolveTOH(5, dest, source, temp);
            dest.Push(source.Pop());
            SolveTOH(6, temp, source, dest);
            }
            ***/
            return true;
        }

        static public Stack<int> A = new Stack<int>();
        static public Stack<int> B = new Stack<int>();
        static public Stack<int> C = new Stack<int>();

        static public void PrintStacks()
        {
            if (countA != A.Count ||
            countB != B.Count ||
            countC != C.Count)
            {
                int diffA = A.Count - countA;
                int diffB = B.Count - countB;
                int diffC = C.Count - countC;
                if (diffA == 1)
                {
                    if (diffB == -1)
                        Console.Write("Move Disc " +A.Peek() + " From B To A");
                    else
                        Console.Write("Move Disc " +A.Peek() + " From C To A");
                }
                else if (diffB == 1)
                {
                    if (diffA == -1)
                        Console.Write("Move Disc " +B.Peek() + " From A To B");
                    else
                        Console.Write("Move Disc " +B.Peek() + " From C To B");
                }
                else //if (diffC == 1)
                {
                    if (diffA == -1)
                        Console.Write("Move Disc " +C.Peek() + " From A To C");
                    else
                        Console.Write("Move Disc " +C.Peek() + "From B To C");
                }
                countA = A.Count;
                countB = B.Count;
                countC = C.Count;
                Console.WriteLine();
            }

            PrintStack(A);
            Console.Write(" , ");
            PrintStack(B);
            Console.Write(" , ");
            PrintStack(C);
            Console.Write(", ");
        }
        static int countA = 0;
        static int countB = 0;
        static int countC = 0;

        static public void PrintStack(Stack<int> s)
        {
            Stack<int>.Enumerator et = s.GetEnumerator();
            Console.Write("[");
            string str = "";
            while (true)
            {
                if (et.MoveNext() == false)
                    break;
                str += et.Current.ToString();
            }
            for (int i = str.Length - 1; i >= 0; i--)
Console.Write(str[i]);
            Console.Write("]");
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("\nEnter the number of discs(-1 to exit):");
                string s = Console.ReadLine();
                movecount = 0;
                int maxdisc = Convert.ToInt32(s);
                if (maxdisc == -1)
                {
                    Console.WriteLine("Good Bye!");
                    return;
                }
                if (maxdisc <= 1 || maxdisc >= 10)
                {
                    Console.WriteLine("Enter between 2 – 9");
                    continue;
                }
                for (int i = maxdisc; i >= 1; i--)
                    A.Push(i);
                countA = A.Count;
                countB = B.Count;
                countC = C.Count;
                PrintStacks();
                SolveTOH(maxdisc, A, B, C);
                Console.WriteLine("Total Moves = " +movecount);
                while (C.Count > 0)

                    C.Pop();

            }
        }
    }
}