using System;
namespace BST
{

    public class Program
    {
        public static void Main(string[] args)
        {
            Random rand = new Random();
            Animal[] animalArray = new Animal[16];

            //cerates 3 cat objects
            for (int i = 0; i < 3; i++)
            {
                //creates cat object and assigns it to and index in the array
                animalArray[i] = new Cat(rand.Next(0, 1000), "joe" + i, rand.Next(0, 20), (Breed)rand.Next(0, 6), rand.NextDouble() * 25, rand.NextDouble() * 25, rand.NextDouble() * 0);
            }

            //creates 3 snake objects
            for (int i = 3; i < 6; i++)
            {
                //creates snake object and assigns it to and index in the array
                animalArray[i] = new Snake(rand.Next(0, 1000), "john" + i, rand.Next(0, 20), rand.Next(0, 20), rand.Next(2) == 1, rand.NextDouble() * 25, rand.NextDouble() * 25, rand.NextDouble() * 0);
            }

            //creates 5 Bird objects
            for (int i = 6; i < 16; i++)
            {
                //creates bird object and assigns it to and index in the array
                animalArray[i] = new Bird(rand.Next(0, 1000), (birdName)rand.Next(0, 9), rand.Next(0, 20), rand.NextDouble() * 10, rand.NextDouble() * 10, rand.NextDouble() * 2);
            }

            /*foreach (Animal a in animalArray)
                Console.WriteLine(a.ToString());*/

            //`````````````array list
            int numelements = 10;
            Node<Animal> root = null;
            BinarySearch<Animal> catList = new BinarySearch<Animal>();
            BinarySearch<Animal> snakeList = new BinarySearch<Animal>();
            BinarySearch<Animal> ListMerged;

            //``````````````doubly linked


            /////````````````` Start of Main

            //`````````````array list

            //adds cats and snkaes to arraylist
            for (int i = 0; i < 3; i++)
                catList.insert(animalArray[i] , 1);

            for (int i = 3; i < 6; i++)
                snakeList.insert(animalArray[i]);

            ////////merge arraylist
            BinarySearch<Animal> firstBirds = new BinarySearch<Animal>(numelements);
            BinarySearch<Animal> secondBirds = new BinarySearch<Animal>(numelements);


            for (int i = 6; i < 11; i++)
                firstBirds.insert(animalArray[i]);
                
            for (int i = 11; i < 16; i++)
                secondBirds.insert(animalArray[i]);

            

           


           
}