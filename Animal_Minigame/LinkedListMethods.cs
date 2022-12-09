using System;

public class Node
{
    public Node next;
    public Node previous;
    public Animal data;
}

public class DoublyLinkedList
{
    private Node head;
    private Node tail;
    private int count = 0;

    public DoublyLinkedList()
    {
    }

    public void printAllForward()
    {
        Node current = head;
        while (current != null)
        {
            Console.WriteLine(current.data);
            current = current.next;
        }
    }

    public void printAllReverse()
    {
        Node current = tail;
        while (current != null)
        {
            Console.WriteLine(current.data);
            current = current.previous;
        }
    }

    public void AddFront(Animal data)
    {
        if (head == null)
        {
            head = new Node();
            head.data = data;
            head.next = null;
            head.previous = null;
            tail = head;

            count++;
        }
        else
        {
            Node ToAdd = new Node();
            ToAdd.data = data;
            head.previous = ToAdd;
            ToAdd.next = head;
            //   ToAdd.previous = null;
            head = ToAdd;

            count++;
        }
    }

    public void AddLast(Animal data)
    {
        if (head == null)
        {
            head = new Node();
            head.data = data;
            head.next = null;
            head.previous = null;
            tail = head;
            count++;
        }
        else
        {
            Node ToAdd = new Node();
            ToAdd.data = data;
            ToAdd.previous = tail;
            tail.next = ToAdd;
            tail = ToAdd;
            count++;
        }
    }

    public int GetCount()
    {
        return count;
    }

    //play with this
    public void InsertAtRandomLocation(Animal Insert)
    {
        Random rand = new Random();
        // int randnum = GetCount();
        int position = rand.Next(1, GetCount());

        Node ToAdd = new Node();
        ToAdd.data = Insert;
        ToAdd.next = null;
        ToAdd.previous = null;
        tail = head;

        if (position == 1)
        {
            ToAdd.next = head;
            head.previous = ToAdd;
            head = ToAdd;
        }
        else
        {
            Node temp = new Node();
            temp = head;
            for (int i = 1; i < position - 1; i++)
            {
                if (temp != null)
                {
                    temp = temp.next;
                }
            }

            if (temp != null)
            {
                ToAdd.next = temp.next;
                ToAdd.previous = temp;
                temp.next = ToAdd;
            }
            if (ToAdd.next != null)
            {
                ToAdd.next.previous = ToAdd;
            }
            count++;
        }
    }

    public void DeleteFirst()
    {
        //possiblely put this.head

        Node current = head;

        head = head.next;

        current = null;

        if (head != null)
        {
            head.previous = null;
        }
        count--;
    }

    public void DeleteLast()
    {
        Node current = head;

        while (current.next.next != null)
        {
            current = current.next;
        }

        current.next = null;
        tail = current;
        count--;
    }

    public void RotateByN(int rotations,string Direction)
    {
        if (head == tail)
        {
            return "The list is empty";
        }
        if (head.next == null)
        {
            return "The list has one element";
        }
        if (Direction == "Right") { 

            for(int i; i < rotations; i++)
            {
                RotateRight();
            }
        else if((Direction == "Left"){

            for (int i; i < rotations; i++)
            {
                RotateLeft();
            }
        }
    }


    public void secondSwap()
    {
            //go to second last element
            Node current = head;
            Node temp = head.next;

            while (current.next.next != null)
            {
                current = current.next;
            }
            //swap with second
            current.previous = head.next;
            head.next.next = current.next
            head.next = current;

            // put the second element into second to last spot
           tail.previous = temp;
           temp.next = tail;
           temp.previous = tail.previous.previous;

    }



    public void RotateLeft()
    {
        Node current = head;

        head = head.next;

        Node temp = head;

        while (temp.next != null)
        {
            temp = temp.next;
        }

        temp.next = current;
        current.previous = temp;
        current.next = null;
        temp.next.next = null;

        tail = current;
    }

    public void RotateRight()
    {
        Node Temp = tail;

        DeleteLast();
        //corrects count from deletelast method taking one away
        count++;
        head.previous = Temp;
        Temp.next = head;
        Temp.previous = null;
        head = Temp;
    }

    public void DeleteAll()
    {
        Node current = new Node();

        while (head != null)
        {
            current = head;
            head = head.next;
            current = null;
            count--;
        }
    }

    public void Merge(DoublyLinkedList list)
    {
        Node temp = head;

        while (temp.next != null)
        {
            temp = temp.next;
        }

        temp.next = list.head;

        while (temp.next != null)
        {
            temp = temp.next;
        }

        tail = temp;

        count += list.GetCount();

    }

    public Node FindClosest(Position pos)
    {
        Node temp = new Node();
        temp = this.head;
        //closest animal
        Node smallest = new Node();
        
        while (temp.next != null)
        {
            if (temp.previous == null)
            {
                smallest = temp;
            }
            else
            {
                if (ClosestHelper(temp, pos) < (ClosestHelper(smallest, pos)))
                {
                    smallest = temp;
                }
            }

            temp = temp.next;
        }

        // Closest = smallest.data;
        System.Console.WriteLine(smallest.data);

        return smallest;
    }

    public double ClosestHelper(Node temp, Position pos)
    {
        double Disformula = Math.Sqrt((pos.X - temp.data.Pos.X) * (pos.X - temp.data.Pos.X) + (pos.Y - temp.data.Pos.Y) * (pos.Y - temp.data.Pos.Y) + (pos.Z - temp.data.Pos.Z) * (pos.Z - temp.data.Pos.Z));
        return Disformula;
    }

    public double FindDistance(Position pos, Animal animal)
    {
        double Distance = Math.Sqrt((pos.X - animal.Pos.X) * (pos.X - animal.Pos.X) + (pos.Y - animal.Pos.Y) * (pos.Y - animal.Pos.Y) + (pos.Z - animal.Pos.Z) * (pos.Z - animal.Pos.Z));

        return Distance;
    }

    public void GetEaten(Animal target)
    {
        //delete
        Node temp = head;
        //loops maybe wrong
        while (temp.next != null)
        {
            if (temp.data == target)
            {
                if (temp == head)
                {
                    head = temp.next;
                    head.previous = null;
                    break;
                }
            }

            if (temp.next.data == target)
            {
                if (temp.next == tail)
                {
                    DeleteLast();
                    break;
                }
                else
                {
                    temp.next = temp.next.next;
                    temp.next.previous = null;
                    temp.next.previous = temp;

                    break;
                }
            }

            temp = temp.next;
        }
        count--;
        Console.WriteLine("The animal " + target.ToString() + " was eaten.");
    }
}