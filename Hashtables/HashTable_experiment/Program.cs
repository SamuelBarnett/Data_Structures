using System;
using System.Diagnostics; // Required for stopwatch

//Your name here
// Samuel Barnett

namespace Assignment3Template
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CircularArray<SO> priorityArray = new CircularArray<SO>(4);
            CircularLinkedList<SO> priorityLL = new CircularLinkedList<SO>();

            Random rand = new Random();
            //for (int i = 0; i < 11; i++)
            // {
                  SO obj1 = new SO(1);
                  SO obj2 = new SO(2);
                  SO obj3 = new SO(3);
                  SO obj4 = new SO(4);
                  SO obj5 = new SO(5);
                  SO obj6 = new SO(6);
                  SO obj7 = new SO(7);
                  SO obj8 = new SO(8);
                  SO obj9 = new SO(9);
                  SO obj10 = new SO(10);
                  SO obj11 = new SO(11);
                  SO obj12 = new SO(12);
                  SO obj13 = new SO(13);
                  SO obj14 = new SO(14);

            //  }

         /*   priorityArray.enqueue(obj2);
            priorityArray.enqueue(obj3);
            priorityArray.enqueue(obj1);
            priorityArray.enqueue(obj4);
            priorityArray.enqueue(obj6);
            priorityArray.enqueue(obj5);
            priorityArray.enqueue(obj9);
            priorityArray.enqueue(obj8);
            priorityArray.enqueue(obj9);
            priorityArray.enqueue(obj10);
            priorityArray.enqueue(obj11);
            priorityArray.enqueue(obj12);
            priorityArray.enqueue(obj13);
            priorityArray.deleteAll();

            priorityArray.printAll();*/

            /*       priorityLL.enqueue(obj1);
                   priorityLL.enqueue(obj2);
                   priorityLL.enqueue(obj3);
                   priorityLL.enqueue(obj1);
                   priorityLL.enqueue(obj6);
                   priorityLL.enqueue(obj5);
                   priorityLL.enqueue(obj7);
                   priorityLL.enqueue(obj2);
                   priorityLL.enqueue(obj3);
                   priorityLL.deleteAll();
                   priorityLL.printAll();
 */


            /*```````````````````````````````````
             * TESTING METHODS
            Array:
                 priorityArray.deleteAll();
                 priorityArray.printAll();

            Linked list:
               priorityLL.deleteAll();
               priorityLL.dequeue();

            `````````````````````````````````````*/

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            // in here is where you do the thing that's being timed

            int largestSize = 0;
            int Size = 0;
            int count = 0;
            TimeSpan ts = stopWatch.Elapsed;
            while(count < 1000)
            //while (ts.Seconds < 5)
            {
                int n_events = rand.Next(1, 12);
                int choice = rand.Next(2);
                if (choice == 0)
                {
                    for (int i = 0; i < n_events; i++)
                    {
                        var nullCheck = priorityLL.dequeue();
                        //priorityArray.dequeue();
                        // priorityLL.dequeue();

                        if (nullCheck != null)
                        {
                            Size--;
                        }
                        count++;
                    }
                }
                else
                {
                    for (int i = 0; i < n_events; i++)
                    {
                        SO obj = new SO(rand.Next(1, 6));
                        //priorityLL.enqueue(obj);
                        //priorityArray.enqueue(obj);
                        priorityLL.enqueue(obj);

                        Size++;
                        count++;
                    }
                }
                if (Size > largestSize)
                {
                    largestSize = Size;
                }
                ts = stopWatch.Elapsed;
            }

            Console.WriteLine("The size:" + Size);

            Console.WriteLine("The largest size:" + largestSize);

            Console.WriteLine("Total number of objects added or removed:"+ count);


            stopWatch.Stop();
            // TimeSpan ts = stopWatch.Elapsed;
            long tsticks = stopWatch.ElapsedTicks;
            Console.WriteLine();

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            /*
             * Hashtable code
             *
             */
            string[] demostrings = { "Srivastava", "Hurley", "Mitchell", "McConnell", "Feng", "Noorian", "Young",
                "Smith", "Northrop", "Andreau", "Reid", "Alam", "Addas", "Atkinson", "Hickson", "Aniag", "Patrick",
                "Subramanian", "Pollanen", "Bruder", "Beland", "Akaiso", "Hircock", "Erzurumluoglu", "Neels"};
            Console.WriteLine("Hashmap Testign");
            int size = 18;
            HashTable<string> myhashtable = new HashTable<string>(size);

            for (int i = 0; i < demostrings.Length; i++)
            {
                myhashtable.Add(demostrings[i]);
            }

            Console.WriteLine( myhashtable.Find("Hurley"));

            myhashtable.printAll();



            Console.WriteLine("My name is: Samuel Barnett");
        }
    }
}