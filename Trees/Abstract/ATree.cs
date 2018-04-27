using System;

namespace Trees.Abstract
{
    public abstract class ATree<T>
    where T : IComparable
    {
        public abstract bool Contains(T key);
        public abstract void Insert(T key);
        public abstract void Remove(T key);
    }
}