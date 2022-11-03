using System;

namespace Assignment3Template
{
    // You are probably better to use the Circular array you made in the lab

    public class CircularArray<T> where T : IComparable
    {
        private T[] array;
        private int queueFront;
        private int queueRear;

        // Basic Constructor
        // Creates an array and initializes the front and rear
        // O(1) in time O (N) in size
        public CircularArray(int size)
        {
            array = new T[size + 1];
            queueFront = 0;
            queueRear = 0;
        }

       
        // NYI fully.
        public void enqueue(T value)  //addBack is enqueue
        {

            // O(N), It searchs for priority in O(N), grows in O(N),
            // and moves the array back one in O(N), depending on how big your array is


            // adds an element based on priority.
            if(((queueRear + 1) % array.Length) == 0)
            {
                //calls grow method that is O(N)
                Grow(array.Length * 2);
            }

            //if queue is empty
            if (queueFront == queueRear)
            {
                array[queueRear] = value;
            }
            else
            {
                array[queueRear] = value;
                int prior = queueRear;
                
                for (int i = queueRear - 1; i >= queueFront; i--)
                {
                    //compare priority
                    if (array[queueRear].CompareTo(array[i]) > 0)
                    {
                        prior--;
                    }
                }
                //moves the array indexes down by one
                //O(N)
                for (int i = queueRear - 1; i >= prior; i--)
                {
                    array[i + 1] = array[i];
                }
                //inserts value at proper index
                array[prior] = value;
            }
           //sets new queuerear
            queueRear = (queueRear + 1) % array.Length;
        }



        public void Grow(int newsize)
        {
            // This is also O(N) because it grows depending on how many array indexs it has to move
            CircularArray<T> newArray = new CircularArray<T>(newsize);
            T current = array[queueFront];
            while (current != null)
            {
                newArray.enqueue(current);
                queueFront = (queueFront + 1) % array.Length;
                current = array[queueFront];
            }
            array = newArray.array;
            queueFront = newArray.queueFront;
            queueRear = newArray.queueRear;
        }

        //Also Not Yet Implemented fully
        // Note that I've made it return the value being removed, that's not strictly required but makes the most sense.
        public T dequeue()  //removeFront is dequeue
        {
            // This is O(1) because it will remove one index
            if (queueFront == queueRear)
            {
                return default;
            }
            T sample = array[queueFront];

            array[queueFront] = default;


            queueFront = (queueFront + 1) % array.Length;
            return sample;
        }


        public void printAll()
        {
            //This is O(N) because is depends on how many indexes it is printing
            for (int i = 0; i < array.Length; i++)
            {
                if(array[i] != null)
                {
                    Console.WriteLine(array[i].ToString());
                }
            }
        }

        public void deleteAll()
        {
            // O(N) depends on how big the array is
            // dequeue all elements.
            for (int i = 0; i < queueRear; i++)
                dequeue();
        }


    }



}

// Same old Grow, bit hard to know where to use it if at all though...
// O(N)
/* public void Grow(int newsize)
 {
     CircularArray<T> newArray = new CircularArray<T>(newsize);
     T current = array[queueFront];
     while (current != null)
     {
         newArray.addBack(current);
         queueFront = (queueFront + 1) % array.Length;
         current = array[queueFront];
     }
     array = newArray.array;
     queueFront = newArray.queueFront;
     queueRear = newArray.queueRear;
 }*/

//`````````````````````````
// Given Circular array
//```````````````````````````

/*

class CircularArray<T>
    {
        T[] thisarray;
        private int front = 0; // index of front element
        private int back = 0; // index of back element
        public CircularArray() // constructor
        { thisarray = new T[20]; }

        public CircularArray(int size) // constructor with a size
        { thisarray = new T[size]; }
        public void enqueue(T input, int inputPriority)
        {
            // adds an element based on priority.
            // Items with equal priority should be FIFO, but higher priorty should come first (so priority 5 jumps ahead of priority 4)
        }

        public T dequeue()
        {
            T temp = thisarray[front]; //

            return temp;
        }
        public void printAll()
        {
            foreach (T x in thisarray)
            Console.WriteLine(x.ToString());
        }
        public void deleteAll()
        {
            // dequeue all elements.
        }
    }
}
*/