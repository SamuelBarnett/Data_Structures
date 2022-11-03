using System;

public class ArrayList<T>
{
    private T[] array;
    private int next = 0;

    //  Represents the next location in the array
    public int Next
    {
        get { return next; }
        set { next = value; }
    }

    //constructor
    public ArrayList(int size)
    {
        array = new T[size + 1];
    }

    //grows the size of the array
    private void Grow(int newSize)
    {
        T[] newArray = new T[newSize * 2];

        for (int i = 0; i < array.Length; i++)
        {
            newArray[i] = array[i];
        }

        array = newArray;
    }

    // adds value to the beginning of the array
    public void AddFront(T value)
    {
        if (next >= array.Length)
        {
            Grow(array.Length);
        }
        if (array[0] == null)
        {
            array[0] = value;
        }
        else
        {
            for (int i = GetCount() - 1; i >= 0; i--)
            {
                array[i + 1] = array[i];
            }
        }
        array[0] = value;
    }

    //returns the number of values in the array
    public int GetCount()
    {
        int count = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] != null)
            {
                count++;
            }
        }

        return count;
    }

    // add the value to the last spot in the array
    public void AddLast(T value)
    {
        if (next >= array.Length)
        {
            Grow(array.Length);
        }
        if (array[0] == null)
        {
            array[0] = value;
        }
        else
        {
            array[GetCount()] = value;
        }
    }

    public void InsertBefore(T before, T after)
    {
        // figure out how to find where the position of the the object is
        if (next >= array.Length)
        {
            Grow(array.Length);
        }

        int position = 0;

        // find the position of after
        for (int i = 0; i < array.Length; i++)
        {
            if (after.Equals(array[i]) == true)
            {
                position = i;
                break;
            }
        }
        //if its null just put it in
        if (array[position--] == null)
        {
             
            array[position--] = before;
        }
        else
        {
            position++;
            // move everything in the array up one index
            for (int i = GetCount() - 1; i >= position; i--)
            {
                array[i + 1] = array[i];
            }

            array[position] = before;
        }
    }

    public void InPlaceSort()
    {
        Array.Sort(array);
    }

    public void Swap(int index1, int index2)
    {
        T a = array[index1];
        array[index1] = array[index2];

        array[index2] = a;
    }

    public void DeleteFirst()
    {
        array[0] = default(T);
        // move all elements of the array down one index
        for (int i = 1; i <= GetCount(); i++)
        {
            array[i - 1] = array[i];
        }
    }

   
    public void DeleteLast()
    {
        array[GetCount() - 1] = default(T);
       
    }

    public void RotateRight()
    {
        for (int i = GetCount() - 1; i >= 0; i--)
        {
            array[i + 1] = array[i];
        }

        array[0] = array[GetCount() - 1];

        array[GetCount() - 1] = default(T);
    }

    public void RotateLeft()
    {
        array[GetCount()] = array[0];

        for (int i = 1; i <= GetCount(); i++)
        {
            array[i - 1] = array[i];
        }
    }

    public static ArrayList<T> ArrayListMerge(ArrayList<T> List1, ArrayList<T> List2)
    {
        int arraySize = List1.GetCount() + List2.GetCount();
        int j = 0;
        ArrayList<T> MergeArray = new ArrayList<T>(arraySize);

        for (int i = 0; i < List1.GetCount(); i++)
        {
            MergeArray.array[i] = List1.array[i];
        }

        for (int i = List1.GetCount(); i < MergeArray.array.Length; i++)
        {
            MergeArray.array[i] = List2.array[j];
            j++;
        }

        return MergeArray;
    }

    public string StringPrintAllForward()
    {
        string printIndex = "";
        for (int i = 0; i < array.Length; i++)
        {
            printIndex += $"{array[i]} \n";
        }
        return printIndex;
    }

    public string StringPrintAllReverse()
    {
        string printIndex = "";
        for (int i = GetCount() - 1; i >= 0; i--)
        {
            printIndex += $"{array[i]} \n";
        }
        return printIndex;
    }

    
    public void DeleteAll()
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = default(T);
        }
    }
}