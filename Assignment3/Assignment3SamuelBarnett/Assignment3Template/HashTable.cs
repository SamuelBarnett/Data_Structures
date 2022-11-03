using System;

namespace Assignment3Template
{
    internal class HashTable<T>
    {
        private T[] hasharray;

        public HashTable(int size)
        { hasharray = new T[size]; }

        public void Add(T value)
        {
            // O(N) because it searches the array so it depends on how big it is.
            var index = hashkey(value);
            int i = 1;

            //this is where insertion goes
            if (hasharray[index] == null)
            {
                hasharray[index] = value;
            }
            else
            {
                while (hasharray[index] != null)
                {
                    if((index % hasharray.Length) == 0)
                    {
                        Grow(hasharray.Length * 2);
                    }
                    // quadratic probing
                    index = (index + i * i) % hasharray.Length;
                    i++;
                }

                hasharray[index] = value;
            }

           
        }
        public void Grow(int newsize)
        {
            // O(N) depends on how many indexs you have to move
            T[] array = new T[hasharray.Length * 2];

            for (int i = 0; i < hasharray.Length; i++)
            {
                array[i] = hasharray[i];
            }
            hasharray = array;

        }
        //Find a given value in the 
        private int find(T value)
        {
            //
            int index = 0;
            int i = 0;
            int searchCount = 0;
            //searchCount < hasharray.Length * 5
            //Search while the index is null or not equal equal to the value
            while (hasharray[index] == null  || value.ToString() != hasharray[index].ToString())
            {
                index = (index + i * i) % hasharray.Length;
                i++;
                searchCount++;

                // Stops the search if it takes to long to find, meaning its not there.
                if(searchCount > hasharray.Length * 2)
                {
                    return -1;
                }
            }
            if (value.ToString() == hasharray[index].ToString())
            {
                return index;
            }

            return -1;
        }

        public bool Find(T value)
        {
            if (this.find(value) >= 0) return true;
            else return false;
        }



        public void printAll()
        {
            // O(N) depends on size on array
            for (int i = 0; i < hasharray.Length; i++)
            {
                if (hasharray[i] != null)
                {
                    Console.WriteLine(hasharray[i].ToString());
                }
            }
        }



        public static int hashkey(T value)
        {
            // if you want you can use a better hashing function here but that seems like it requires effort.
            return value.ToString().Length;
        }
    }
}