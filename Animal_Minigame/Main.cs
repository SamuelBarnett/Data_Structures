using System;

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
        ArrayList<Animal> catList = new ArrayList<Animal>(numelements);
        ArrayList<Animal> snakeList = new ArrayList<Animal>(numelements);
        ArrayList<Animal> ListMerged;

        //``````````````doubly linked

        DoublyLinkedList firstBirds = new DoublyLinkedList();

        DoublyLinkedList secondBirds = new DoublyLinkedList();

        

        /////````````````` Start of Main

        //`````````````array list

        //adds cats and snkaes to arraylist
        for (int i = 0; i < 3; i++)
            catList.AddFront(animalArray[i]);

        for (int i = 3; i < 6; i++)
            snakeList.AddLast(animalArray[i]);

        ////////merge arraylist
        ListMerged = ArrayList<Animal>.ArrayListMerge(catList, snakeList);


        for (int i = 6; i < 11; i++)
            firstBirds.AddLast(animalArray[i]);
        for (int i = 11; i < 16; i++)
            secondBirds.AddLast(animalArray[i]);

        firstBirds.Merge(secondBirds);
        ////// TESTING
       // ListMerged.Swap(1, 2);
        // Console.WriteLine(ListMerged.StringPrintAllReverse());
        // ListMerged.InPlaceSort();
        //  catList.RotateRight();
        //     ListMerged.DeleteAll();
        //     Console.WriteLine(ListMerged.StringPrintAllReverse());
        //for (int i = 6; i < 11; i++)
        //    firstBirds.AddLast(animalArray[i]);
        //for (int i = 11; i < 16; i++)
        //    secondBirds.AddLast(animalArray[i]);
        //firstBirds.InsertAtRandomLocation(animalArray[2]);
        //  firstBirds.Merge(secondBirds);
        //firstBirds.RotateRight();
        //    firstBirds.DeleteAll();
        //    firstBirds.printAllReverse();
        // Console.WriteLine("The position is" + animalArray[0].Pos);
        // firstBirds.FindClosest(animalArray[0].Pos);
        // Console.WriteLine(firstBirds.FindDistance(animalArray[0].Pos, animalArray[1]));



       
        var end = false;
        while (end != true)
        {
            //counts from animals 6 to 16 because they are birds
            for (int i = 6; i < 16; i++)
            {
                //itterating through cats and snakes
                for (int j = 0; j < 3; j++)
                {
                    //  console.writeline(firstbirds.finddistance(animalarray[i].pos, animalarray[j]) + "snake");

                    double distanceaway = firstBirds.FindDistance(animalArray[j].Pos, animalArray[i]);

                    if (distanceaway <= 8)
                    {
                        firstBirds.GetEaten(animalArray[i]);
                        break;
                    }
                    //else
                    //{
                    //    firstbirds.findclosest(animalarray[i].pos);
                    //}
                }
                for (int j = 3; j < 6; j++)
                {
                    // console.writeline(firstbirds.finddistance(animalarray[i].pos, animalarray[j]) + "cat");

                    double distanceaway = firstBirds.FindDistance(animalArray[j].Pos, animalArray[i]);

                    if (distanceaway <= 3)
                    {
                        firstBirds.GetEaten(animalArray[i]);
                        break;
                    }
                    //else
                    //{
                    //    firstbirds.findclosest(animalarray[i].pos);

                    //}
                }
                if (firstBirds.GetCount() == 0)
                {
                    end = true;
                }
            }
        }

        Console.ReadLine();
    }
}