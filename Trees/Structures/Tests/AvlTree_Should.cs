using System.Linq;
using NUnit.Framework;

namespace Trees.Structures.Tests
{
    [TestFixture]
    public class AvlTree_Should
    {
        private AvlTree<int> _tree;

        [SetUp]
        public void SetUp()
        {
            _tree = new AvlTree<int>();
        }

        [Test]
        public void AddFirstElement()
        {
            _tree.Insert(1);
            Assert.IsTrue(_tree.Contains(1));
            Assert.AreEqual(1, _tree.Count);
        }

        [Test]
        public void ContainsAllAddedElements()
        {
            var elements = new[] {1, 2, 9, 23, 3, -5, 10}.ToList();
            elements.ForEach(x => _tree.Insert(x));
            var containsAllItems = elements.All(_tree.Contains);

            Assert.IsTrue(containsAllItems);
            Assert.AreEqual(elements.Count, _tree.Count);
        }

        [Test]
        public void AddSameElements()
        {
            var element = 2;
            for (var i = 0; i < 5; i++)
                _tree.Insert(element);

            Assert.IsTrue(_tree.Contains(element));
            Assert.AreEqual(5, _tree.Count);
        }

        [Test]
        public void RemoveRootElement()
        {
            _tree.Insert(1);
            _tree.Remove(1);

            Assert.IsFalse(_tree.Contains(1));
            Assert.AreEqual(0, _tree.Count);
        }

        [Test]
        public void RemoveRepeatingElement()
        {
            var elements = new[] {1, 2, 2, 5}.ToList();
            elements.ForEach(x => _tree.Insert(x));
            _tree.Remove(2);

            Assert.IsTrue(_tree.Contains(2));
            Assert.AreEqual(elements.Count - 1, _tree.Count);
        }

        [Test]
        public void RemoveElement()
        {
            var elements = new[] {1, 3, 5, 4, 2}.ToList();
            elements.ForEach(x => _tree.Insert(x));
            _tree.Remove(5);
            var containsAllItemsExcept5 = elements.Where(x => x != 5).All(_tree.Contains);

            Assert.IsFalse(_tree.Contains(5));
            Assert.IsTrue(containsAllItemsExcept5);
        }

        [Test]
        public void RemoveNotExistingElement()
        {
            var elements = new[] {1, 2, 9}.ToList();
            elements.ForEach(x => _tree.Insert(x));
            _tree.Remove(-10);
            var containsAllElements = elements.All(_tree.Contains);

            Assert.IsTrue(containsAllElements);
            Assert.AreEqual(elements.Count, _tree.Count);
        }
    }
}