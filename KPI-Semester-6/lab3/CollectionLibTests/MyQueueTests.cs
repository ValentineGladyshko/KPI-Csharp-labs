using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Collection.Lib.Tests
{
    [TestClass]
    public class MyQueueTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]

        public void Dequeue_DequeueFromEmptyQueue_ShouldThrowInvalidOperationException()
        {
            var queue = new MyQueue<int>();

            queue.Dequeue();
        }

        [TestMethod]

        public void Dequeue_Dequeue3FromQueue_3Returned()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(6);

            var num = queue.Dequeue();

            NUnit.Framework.Assert.AreEqual(3, num);
        }

        [TestMethod]

        public void Dequeue_Dequeue3FromQueue_QueueIsEmpty()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);

            queue.Dequeue();

            NUnit.Framework.CollectionAssert.IsEmpty(queue);
        }

        [TestMethod]

        public void Enqueue_Enqueue3ToQueue_3InTheHeadOfQueue()
        {
            var queue = new MyQueue<int>();

            queue.Enqueue(3);
            queue.Enqueue(4);

            NUnit.Framework.Assert.AreEqual(queue.Peek(), 3);
            //NUnit.Framework.Assert.Contains(3, queue);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]

        public void Peek_PeekFromEmptyQueue_ShouldThrowInvalidOperationException()
        {
            var queue = new MyQueue<int>();

            queue.Peek();
        }

        [TestMethod]

        public void Peek_PeekFromQueue_3Returned()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(4);

            var num = queue.Peek();

            NUnit.Framework.Assert.AreEqual(3, num);
        }

        [TestMethod]

        public void ToArray_IntQueueToArray_IntArrayReturned()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(-6);

            var array = queue.ToArray();

            NUnit.Framework.Assert.IsInstanceOf(typeof(int[]), array);
        }

        [TestMethod]

        public void ToArray_QueueWithValuesToArray_ArrayWithValuesReturned()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(-6);

            var array = queue.ToArray();

            NUnit.Framework.CollectionAssert.AreEqual(array, queue);
        }

        [TestMethod]

        public void Contains_QueueContains6_TrueReturned()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(-3);
            queue.Enqueue(6);

            var flag = queue.Contains(6);

            NUnit.Framework.Assert.IsTrue(flag);
        }

        [TestMethod]

        public void Contains_QueueContains6_FalseReturned()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(-3);
            queue.Enqueue(-6);

            var flag = queue.Contains(6);

            NUnit.Framework.Assert.IsFalse(flag);
        }

        [TestMethod]

        public void Clear_ClearQueue_QueueIsEmpty()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(-2);

            queue.Clear();

            NUnit.Framework.CollectionAssert.IsEmpty(queue);
        }

        [TestMethod]

        public void CopyTo_CopyToNullArray_ShouldThrowArgumentNullException()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(-2);
            int[] array = null;

            try
            {
                queue.CopyTo(array, 0);
            }

            catch(ArgumentNullException)
            {
                return;
            }

            NUnit.Framework.Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]

        public void CopyTo_CopyToArrayWithInvalidIndex_ShouldThrowArgumentOutOfRangeException()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(-2);
            int[] array = new int[2];

            queue.CopyTo(array, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]

        public void CopyTo_CopyToSmallArray_ShouldThrowArgumentException()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(-2);
            int[] array = new int[1];

            queue.CopyTo(array, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]

        public void CopyTo_QueueSize2CopyToArraySize3Index2_ShouldThrowArgumentException()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(-2);
            int[] array = new int[3];

            queue.CopyTo(array, 2);
        }

        [TestMethod]

        public void CopyTo_QueueCopyToArrayWithTheSameSize_ArrayEqualQueue()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(-2);
            int[] array = new int[2];

            queue.CopyTo(array, 0);

            NUnit.Framework.CollectionAssert.AreEqual(array, queue);
        }

        [TestMethod]

        public void CopyTo_QueueCopyToLargerArray_ArrayIsSupersetOfQueue()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(-2);
            int[] array = new int[3];
            array[2] = 100;

            queue.CopyTo(array, 0);

            NUnit.Framework.CollectionAssert.IsSupersetOf(array, queue);
        }

        [TestMethod]

        public void CopyTo_CopyToNullArrayClass_ShouldThrowArgumentNullException()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(-2);
            Array array = null;

            try
            {
                queue.CopyTo(array, 0);
            }

            catch (ArgumentNullException)
            {
                return;
            }

            NUnit.Framework.Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]

        public void CopyTo_CopyToArrayClassWithInvalidIndex_ShouldThrowArgumentOutOfRangeException()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(-2);
            Array array = new int[2];

            queue.CopyTo(array, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]

        public void CopyTo_CopyToSmallArrayClass_ShouldThrowArgumentException()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(-2);
            Array array = new int[1];

            queue.CopyTo(array, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]

        public void CopyTo_QueueSize2CopyToArrayClassSize3Index2_ShouldThrowArgumentException()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(-2);
            Array array = new int[3];

            queue.CopyTo(array, 2);
        }

        [TestMethod]

        public void CopyTo_QueueCopyToArrayClassWithTheSameSize_ArrayEqualQueue()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(-2);
            Array array = new int[2];

            queue.CopyTo(array, 0);

            NUnit.Framework.CollectionAssert.AreEqual(array, queue);
        }

        [TestMethod]

        public void CopyTo_QueueCopyToLargerArrayClass_ArrayIsSupersetOfQueue()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(-2);
            Array array = new int[3];
            array.SetValue(100, 2);

            queue.CopyTo(array, 0);

            NUnit.Framework.CollectionAssert.IsSupersetOf(array, queue);
        }
    }
}