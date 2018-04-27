using System;
using Trees.Structures;

namespace Trees
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var tree = new RandomizingTree<int>();
            for (var i = 0; i < 1000000; i++)
                tree.Insert(i);
            var a = 10;
        }
    }
}