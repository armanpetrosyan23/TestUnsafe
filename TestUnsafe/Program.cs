using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnsafe
{
    class Program
    {
        static unsafe void Main(string[] args)
        {
            int length = (int)10E7;
            Stopwatch timer = new Stopwatch();
            int[] test = new int[length];

            fixed (int* p = &test[0])
            {
                timer.Start();

                for (int i = 0; i < length; i++)
                {
                    *(p + i) = i;
                    int value = (int)*(p + i);

                }
                timer.Stop();
                Console.WriteLine(timer.ElapsedMilliseconds);
            }

            int[] test1 = new int[length];
            timer.Start();
            for (int i = 0; i < length; i++)
            {
                test1[i] = i;
                int value = test[i];
            }
            timer.Stop();
            Console.WriteLine(timer.ElapsedMilliseconds);
          
            // pointer result twice faster

        }

        static unsafe void ArrayInStack()
        {

            int length = (int)10E5;
            Stopwatch timer = new Stopwatch();

            int* pArray = stackalloc int[length];
            timer.Start();

            for (int i = 0; i < length; i++)
            {
                Math.Pow((int)*(pArray + i), i);

            }

            timer.Stop();
            Console.WriteLine(timer.ElapsedMilliseconds);

            int[] array = new int[length];
            timer.Start();
            for (int i = 0; i < length; i++)
            {
                Math.Pow(array[i], i);
            }
            timer.Stop();
            Console.WriteLine(timer.ElapsedMilliseconds);

            // pointer result twice faster
        }


        static unsafe void MemoryLocation()
        {
            int p1 = 32000000;

            int* pointer1 = (int*)&p1;

            //This is address in memory 
            Console.WriteLine((long)(pointer1));
            for (int i = 0; i < 4; i++)
            {
                //This is address in memory after add one bytes 
                Console.WriteLine((int)((byte*)pointer1 + i));
                Console.WriteLine((*((byte*)pointer1 + i)));

            }


        }

    }
}


