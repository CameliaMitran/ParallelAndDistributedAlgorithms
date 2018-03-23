using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProdConsBW
{
    class ProducerConsumer
    {
        const int size = 20;
        //private Object m_lock = new Object();
        private Mutex m_lock = new Mutex();
        // private Mutex mut_free = new Mutex();
        // private Mutex mut_full = new Mutex();
        private Queue<int> my_queue = new Queue<int>();
        int items_c;
        int items_p = 0;

        public void Producer()
        {

            while (true)
            {

                lock (m_lock)
                {

                    if (items_p < size)
                    {


                        //m_lock.WaitOne();
                        Console.WriteLine("produce {0}", items_p);
                        my_queue.Enqueue(items_p);
                        items_p++;
                        /* m_lock.ReleaseMutex();

                         try
                         {
                             m_lock.WaitOne();
                         }
                         catch { }
                         */
                    }
                }
                Thread.Sleep(100);
            }

        }

        public void Consumer()
        {
            while (true)

            {

                lock (m_lock)   //marcheaza zona critica
                {
                    // m_lock.WaitOne();
                    if (items_p > 0)
                    {
                        //Thread.Sleep(100);

                        items_c = my_queue.Dequeue();
                        try
                        {
                            my_queue.Enqueue(items_p);
                        }
                        catch { }



                        Console.WriteLine("Consume {0}", items_c);
                        items_p--;

                        /* m_lock.ReleaseMutex();
                         try
                         {
                             m_lock.WaitOne();
                         }
                         catch { }
                         */

                    }
                }

                Thread.Sleep(100);

            }


        }
    }
}

