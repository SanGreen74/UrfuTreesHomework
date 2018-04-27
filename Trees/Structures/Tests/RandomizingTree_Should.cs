using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Trees.Structures.Tests
{
    [TestFixture]
    public class RandomizingTree_Should
    {
        private RandomizingTree<int> _tree;

        [SetUp]
        public void SetUp()
        {
            _tree = new RandomizingTree<int>();
        }

        [Test]
        public void AddFirstElement()
        {
            const int value = 10;
            _tree.Insert(value);
            Assert.IsTrue(_tree.Contains(value), "Tree should be contains value after adding");
            Assert.AreEqual(1, _tree.Count, "After removing one element amount of tree's elements should be equels to 1");
        }

        [Test]
        public void ContainsAllAddedElements()
        {
            var collection = InitWithLinearCollection(0, 10, _tree);
            var isContainsAllElement = collection.All(_tree.Contains);

            Assert.IsTrue(isContainsAllElement);
            Assert.AreEqual(collection.Count, _tree.Count);
        }

        [Test]
        public void CountDifferentElements()
        {
            var collection = InitWithLinearCollection(0, 10, _tree);
            
            Assert.AreEqual(collection.Count, _tree.Count, $"Element's amount in tree doesn't equals to expected amount");
        }

        [Test]
        public void CountSameElemenets()
        {
            var collection = Enumerable.Range(0, 10).ToList();
            const int element = 2;
            collection.ForEach(x => _tree.Insert(element));
            
            Assert.AreEqual(collection.Count, _tree.Count, $"Element's amount in tree doesn't equals to expected amount");
        }

        [Test]
        public void RemovingOneElement()
        {
            const int removingKey = 5;
            var collection = InitWithLinearCollection(0, 10, _tree);
            _tree.Remove(removingKey);

            Assert.IsFalse(_tree.Contains(removingKey));
            Assert.IsTrue(collection
                .Where(x => x != removingKey)
                .All(_tree.Contains));
            Assert.AreEqual(collection.Count - 1, _tree.Count, "Element's amount after removing 1 element should be equals to 9");
        }

        [Test]
        public void RemovingSeveralElements()
        {
            var collection = InitWithLinearCollection(0, 10, _tree);
            var removingKeys = new[] {1, 3, 6, 9}.ToList();
            removingKeys.ForEach(_tree.Remove);
            
            var removingAllKeys = removingKeys.All(x => !_tree.Contains(x));
            var containsAllNotRemoving = collection.Where(x => !removingKeys.Contains(x))
                .All(_tree.Contains);
            
            Assert.AreEqual(collection.Count - removingKeys.Count, _tree.Count,
                "Incorrect elements count in tree after removing");
            Assert.IsTrue(removingAllKeys, "Not all keys was removing");
            Assert.IsTrue(containsAllNotRemoving, "Not all keys contains in tree after removing");
        }

        [Test]
        public void RemovingLastElement()
        {
            _tree.Insert(10);
            _tree.Remove(10);
            Assert.AreEqual(0, _tree.Count);
        }

        [Test]
        public void RemoveNotExistingElement()
        {
            _tree.Insert(1);
            _tree.Insert(3);
            _tree.Remove(10);

            Assert.AreEqual(2, _tree.Count);
            Assert.IsTrue(_tree.Contains(1));
            Assert.IsTrue(_tree.Contains(3));
        }

        [Test]
        public void RemovingRepeatingElement()
        {
            const int element = 2;
            const int count = 5;
            for (var i = 0; i < count; i++)
                _tree.Insert(element);
            _tree.Remove(element);

            Assert.IsTrue(_tree.Contains(element));
            Assert.AreEqual(count - 1, _tree.Count);
        }

        private List<int> InitWithLinearCollection(int start, int count, RandomizingTree<int> tree)
        {
            var collection = Enumerable.Range(start, count).ToList();
            collection.ForEach(tree.Insert);
            return collection;
        }
    }
}