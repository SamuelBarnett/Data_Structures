using System;
namespace BST
{

    public class Position
    {
        private double x;
        private double y;
        private double z;

        //constructor for posiiton no args
        public Position()
        {
            X = 0.0;
            Y = 0.0;
            Z = 0.0;
        }

        //constructor for posiiton 3 args
        public Position(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        //Property with getters and setters for X
        public double X
        {
            get { return x; }
            set
            {
                // Restricts the value of x to +-10
                x = Math.Clamp((value), -10, 10);
            }
        }

        //Property with getters and setters for Y
        public double Y
        {
            get { return y; }
            set
            {
                // Restricts the value of y to +-10
                y = Math.Clamp((value), -10, 10);
            }
        }

        //Property with getters and setters for Z
        public double Z
        {
            get { return z; }
            set
            {
                // Restricts the value of z to +-10
                z = Math.Clamp((value), -10, 10);
            }
        }

        // method that changes the values in position
        public void Move(double dx, double dy, double dz)
        {
            x = Math.Clamp((x + dx), -100, 100);
            y = Math.Clamp((y + dy), -100, 100);
            z = Math.Clamp((z + dz), -100, 100);
        }

        // ToString method for Position
        public override string ToString()
        {
            return $"X:{X:F1},Y:{Y:F1}, Z:{Z:F1}";
        }
    }

    public enum Breed
    {
        Abyssinian,
        British_Shorthair,
        Bengal,
        Himalayan,
        Ocicat,
        Serval
    }

    public class Animal
    {
        private int id;
        private string name;
        private double age;
        private Position pos = new Position();

        //property for the ID
        public int ID
        {
            get { return id; }
            set { this.id = value; }
        }

        //property for the AGE
        public double Age
        {
            get { return age; }
            set { this.age = value; }
        }

        //property for the Name
        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        //property for returning the position through Pos
        public Position Pos
        {
            get { return pos; }
            set { pos = value; }
        }

        public int CompareTo(Animal obj)
        {
            return name.CompareTo(obj.Name);
        }

        // method passes to the Position class to calculate the move
        public void Move(double dx, double dy, double dz)
        {
            Pos.Move(dx, dy, dz);
        }

        //empty ToString to be overriden later on
        public override string ToString()
        {
            return "";
        }
    }

    public class Cat<T> : Animal where T : IComparable   
    {
        private Breed mybreed;

        //Constructor for cat to store inputted variables
        public Cat(int input_iD, string input_name, int input_age, Breed input_Breed, double input_x, double input_y, double input_z)
        {
            ID = input_iD;
            Age = input_age;
            mybreed = input_Breed;
            Name = input_name;
            Pos.X = input_x;
            Pos.Y = input_y;
            Pos.Z = input_z;
        }

        // Method to make a vaild string for cat class
        public override string ToString()
        {
            return "The cat ID is: " + ID + " the name is " + Name + " Age: " + Age + " Breed :" + mybreed + " Pos: " + Pos.ToString();
        }
    }

    public class Snake<T> : Animal where T : IComparable
    {
        //Constructor for snake to store inputted variables
        public Snake(int input_iD, string input_name, int input_age, double input_length, bool input_veno, double input_x, double input_y, double input_z)
        {
            ID = input_iD;
            Age = input_age;
            Length = input_length;
            Venomous = input_veno;
            Name = input_name;
            Pos.X = input_x;
            Pos.Y = input_y;
            Pos.Z = input_z;
        }

        //property for length
        public double Length
        {
            get; set;
        }

        //property for venomous
        public bool Venomous
        {
            get; set;
        }

        // Method to make a vaild string for snake class
        public override string ToString()
        {
            return " The snake ID is: " + ID + " the name is: " + Name + " Age: " + Age + " Length: " + Length + " Venomous:" + Venomous + " Pos: " + Pos.ToString();
        }
    }

    public enum birdName
    {
        Tweety,
        Zazu,
        Iago,
        Hula,
        Manu,
        Couscous,
        Roo,
        Tookie,
        Plucky,
        Jay
    }
    //public enum birdName
    //{

    //}
    public class Bird<T> : Animal where T : IComparable
    {
        private birdName name;
        //Constructor for cat to store inputted variables
        public Bird(int input_iD, birdName input_name, int input_age, double input_x, double input_y, double input_z)
        {
            ID = input_iD;
            Age = input_age;
            name = input_name;
            Pos.X = input_x;
            Pos.Y = input_y;
            Pos.Z = input_z;
        }

        // Method to make a vaild string for cat class
        public override string ToString()
        {
            return "The bird ID is: " + ID + " the name is " + name + " Age: " + Age + " Pos: " + Pos.ToString();
        }
    }
}