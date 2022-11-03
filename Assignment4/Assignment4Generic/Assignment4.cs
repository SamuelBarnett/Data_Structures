using System;
using System.Diagnostics;

// Flagrantly stolen from https://gist.github.com/aaronjwood/7e0fc962c5cd898b3181
// including the class file
// Significant modifications by Sri

namespace BST
{


    class BinarySearchTree
    {
        static void Main(string[] args)
        {
            Node root = null;
            BinarySearch<Animal> bst;
            bst = new BinarySearch<Animal>();
            int SIZE = 10; // tested on up to 200k elements and it works fine
            int[] testArray = new int[SIZE];

            int[] fixedNums = { 43, 32, 8, 54, 31, 22, 12, 42, 48, 30 };

            /* Random rnd = new Random();
             Console.WriteLine("Elements to be inserted into the BST");
             for (int i=0; i<fixedNums.Length; i++)
             {
                // testArray[i] = rnd.Next(1, 100);
                 Console.WriteLine(fixedNums[i]);
             }

             for (int i = 0; i < fixedNums.Length; i++)
             {
                 root = bst.insert(root, fixedNums[i]);
             }*/


            //``````` Time testing ````````````````````
            int SIZE2 = 10; // tested on up to 200k elements and it works fine
            int[] timeArray = new int[SIZE2];

            Random rand = new Random();
            Console.WriteLine("Elements to be inserted into the BST");
            for (int i = 0; i < timeArray.Length; i++)
            {
                timeArray[i] = rand.Next(1, 100);
                Console.WriteLine(timeArray[i]);
            }




            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < timeArray.Length; i++)
            {
                root = bst.insert(root, timeArray[i]);
            }
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;
            long tsticks = stopWatch.ElapsedTicks;
            // string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", tsticks.Hours, tsticks.Minutes, tsticks.Seconds, ticks.Milliseconds / 10);
            Console.WriteLine("Size " + SIZE2);
            Console.WriteLine("RunTime " + tsticks);
            Console.WriteLine("End of Timing");
            Console.ReadLine();
            //````````````````````````````````````








            Console.WriteLine("Elements in the Tree, in some order.  Students get to make this work ");
            // - Lab:  Make the following lines of code work. 
            // Lab: Pre-order, Post Order, In order traversals
            //  Console.WriteLine(bst.preOrder(root));
            //  Console.WriteLine(bst.postOrder(root));
            //  Console.WriteLine(bst.inOrder(root));
            //  Console.WriteLine(bst.breadthFirst(root));
            Console.WriteLine(bst.findSmallest(root).value);
            Console.WriteLine(bst.siblingNode(root.left.right).value);
            Console.WriteLine(bst.siblingofParent(root.left.right).value);


            Console.WriteLine(bst.postOrder(root));



            //  bst.traverse(root);

            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
