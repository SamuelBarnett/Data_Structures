using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// 
/// 
///  You shouldn't need to touch anything in this code
///  
/// 
/// 
/// 
/// </summary>
namespace Assignment3Template
{
    // The built in way
    public static class Util // This used the built in C# RNG.  
    {
        private static Random rnd = new Random();
        public static int GetRandom()
        {
            return rnd.Next(9999);
        }
    }
    public class SriRandom  // Switched to a faster XorShift RNG based on some code I pillaged from the web
    {
        private static XorShiftRandom sriRnd = new XorShiftRandom();

        public static ulong GetRandom()
        {
            return (ulong)sriRnd.NextInt32();
        }
        public static double GetRandomDouble()
        {
            return sriRnd.NextDouble();
        }

    }
}
