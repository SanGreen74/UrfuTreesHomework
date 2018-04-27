using System;
using Trees.Structures;

namespace Trees
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var rTree = new RandomizingTree<int>();
            var avlTree = new AvlTree<int>();
            for (var i = 0; i < 1000000; i++)
                rTree.Insert(i);

            for (var i = 0; i < 1000000; i++)
                avlTree.Insert(i);
        }
    }
}