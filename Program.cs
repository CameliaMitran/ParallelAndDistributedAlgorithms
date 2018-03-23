using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProdConsBW
{
    class Program
    {
        static void Main(string[] args)
        {
            ProducerConsumer pc = new ProducerConsumer();

            Thread producer = new Thread(new ThreadStart(pc.Producer));
            Thread consumer = new Thread(new ThreadStart(pc.Consumer));

            producer.Start();
            consumer.Start();

            producer.Join();
            consumer.Join();

            Console.WriteLine("\nPress any key to complete the program.\n");
            Console.ReadKey(false);
        }
    }
}
