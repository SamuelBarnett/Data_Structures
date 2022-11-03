using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3Template
{
    class SO : IComparable
    {
        public int priority;
        public double[] Data;
        private static int sizeofObject = 8191;
        public override string ToString()
        {
            return "Priority: " + priority.ToString() + " " + "D[0]" + Data[0].ToString("G4");
        }
        public SO(int inputkey)
        {
            priority = inputkey;
            Data = new double[sizeofObject];
            for (int i = 0; i < sizeofObject; i++)
            {
                Data[i] = SriRandom.GetRandom();
            }
        }
        public int CompareTo(object obj)
        {
            SO b = obj as SO;
            if (b == null) return 1;

            //this.CompareTo(value) returns < 0 if this < value
            //this.CompareTo(value) returns > 0 if this > value
            if (priority < b.priority)
                return -1;
            if (priority > b.priority)
                return 1;
            else return 0;
        }

    }
}

/*
 class DemoClass : IComparable
{
    public string name;
    public int priority;

    public DemoClass()
    {
        name = "";
        priority = 0;
    }

    public int CompareTo(Object obj)
    {   //CompareTo  
        //this.CompareTo(value) returns < 0 if this < value
        //this.CompareTo(value) returns > 0 if this > value
        DemoClass sample = (DemoClass)obj;

        if (priority < sample.priority) return -1;
        else if (priority > sample.priority) return 1;
        else return 0; // value == sample.value


    }
    public override string ToString()
    {
        return name + " " + priority + " ";
    }

}
*/