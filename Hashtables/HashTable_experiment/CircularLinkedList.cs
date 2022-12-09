using System;

namespace Assignment3Template
{
    internal class CircularLinkedList<T> where T : IComparable
    {
        internal class Node
        {
            internal Node next;
            internal Node previous;
            internal T data;
        }

        private Node front;
        private Node back;

        public CircularLinkedList() // constructor
        { front = back = null; }

        public void enqueue(T input)
        {
            // O(N) Because it searches for priority it is dependant on how big the array is hence O(N).
            // adds an element based on priority.
            Node ToAdd = new Node();
            ToAdd.data = input;

            //if the list is empty
            if (front == null)
            {

                front = ToAdd;
                back = front;

                front.next = back;
                front.previous = back;
            }
            else
            {
                Node Temp = front;
                // check if it is at the end of the circle and compare it to the next priority in the list
                while (Temp.next != front && Temp.data.CompareTo(ToAdd.data) > 0)
                {
                    Temp = Temp.next;
                }
                //priority is the front of the list
                if (Temp == front)
                {
                    ToAdd.next = front;
                    front.previous = ToAdd;

                    ToAdd.previous = back;
                    back.next = ToAdd;

                    front = ToAdd;
                }
                else if (Temp.next == front)
                {
                    //priority is at the back of the list
                    back = ToAdd;
                    front.previous = ToAdd;

                    Temp.next = ToAdd;
                    ToAdd.previous = Temp;

                    ToAdd.next = front;
                }
                else
                {
                    // priority is in the middle
                    Temp.previous.next = ToAdd;
                    ToAdd.previous = Temp.previous;

                    ToAdd.next = Temp;
                    Temp.previous = ToAdd;
                }
            }

        }

        // deletes
        public T dequeue()
        {
            // O(1) only deletes one element 
            if (front != null)
            {
                var sample = front.data;

                if (front.next == front)
                {
                    front = null;
                    back = null;
                   
                }
                else
                {
                    back.next = front.next;

                    front.next.previous = back;

                    front = back.next;
                }

                return sample;
            }
            
            return default;
        }

        public void printAll()
        {
            // O(N) because it depends on how many values are in the array.
            Node current = front;
            if (current != null)
            {
                while (current.next != front)
                {
                    Console.WriteLine(current.data.ToString());
                    current = current.next;
                }
                Console.WriteLine(back.data.ToString());
            }
        }

        public void deleteAll()
        {
            // dequeue all elements.
            // O(N)
            while (front.next != front)
            {
                dequeue();
            }
            dequeue();
        }
    }
}