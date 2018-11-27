using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnsafe
{
    class Program
    {
        static unsafe void Main(string[] args)
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
            /* Output
            9434224           
            9434224
            255
            9434225
            255
            9434226
            255
            9434227
            127
              */

        }
                
    }
}
