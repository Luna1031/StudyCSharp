﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UsingLock
{
    class Counter
    {
        const int LOOP_COUNT = 1000;
        readonly object thisLock;
        public int Count { get; set; }
        public Counter()
        {
            thisLock = new object();
            Count = 0;
        }
        public void Increase()
        {
            int loopcount = LOOP_COUNT;
            while(loopcount-->0)
            {
                lock(thisLock)
                {
                    {
                        Count++;
                        Console.WriteLine(Count);
                    }
                    Thread.Sleep(1);
                }
            }
        }
        public void Decrease()
        {
            int loopcount = LOOP_COUNT;
            while (loopcount-- > 0)
            {
                lock (thisLock)
                {
                    {
                        Count--;
                        Console.WriteLine(Count);
                    }
                    Thread.Sleep(1);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter();

            Thread incThread = new Thread(new ThreadStart(counter.Increase));
            Thread decThread = new Thread(new ThreadStart(counter.Decrease));

            incThread.Start();
            decThread.Start();

            incThread.Join();
            decThread.Join();

            Console.WriteLine(counter.Count);
        }
    }
}
