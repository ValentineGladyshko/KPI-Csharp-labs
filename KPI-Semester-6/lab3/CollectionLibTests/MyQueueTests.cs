using NUnit.Framework;
using System;

namespace Collection.Lib.Tests
{
    [TestFixture]
    public class MyQueueTests
    {
        [Test]

        public void Dequeue_DequeueFromEmptyQueue_ShouldThrowInvalidOperationException()
        {

            var queue = new MyQueue<int>();

            Assert.Catch(typeof(InvalidOperationException), () => queue.Dequeue()); 
        }

        [Test]

        public void Dequeue_Dequeue3FromQueue_3Returned()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(6);

            var num = queue.Dequeue();

            Assert.AreEqual(3, num);
        }

        [Test]

        public void Dequeue_Dequeue3FromQueue_QueueIsEmpty()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);

            queue.Dequeue();

            CollectionAssert.IsEmpty(queue);
        }

        [Test]

        public void Enqueue_Enqueue3ToQueue_3InTheHeadOfQueue()
        {
            var queue = new MyQueue<int>();

            queue.Enqueue(3);
            queue.Enqueue(4);

            Assert.AreEqual(queue.Peek(), 3);
            //Assert.Contains(3, queue);
        }

        [Test]

        public void Peek_PeekFromEmptyQueue_ShouldThrowInvalidOperationException()
        {
            var queue = new MyQueue<int>();

            Assert.Catch(typeof(InvalidOperationException), () => queue.Peek());
        }

        [Test]

        public void Peek_PeekFromQueue_3Returned()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(4);

            var num = queue.Peek();

            Assert.AreEqual(3, num);
        }

        [Test]

        public void ToArray_IntQueueToArray_IntArrayReturned()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(-6);

            var array = queue.ToArray();

            Assert.IsInstanceOf(typeof(int[]), array);
        }

        [Test]

        public void ToArray_QueueWithValuesToArray_ArrayWithValuesReturned()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(-6);

            var array = queue.ToArray();

            CollectionAssert.AreEqual(array, queue);
        }

        [Test]

        public void Contains_QueueContains6_TrueReturned()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(-3);
            queue.Enqueue(6);

            var flag = queue.Contains(6);

            Assert.IsTrue(flag);
        }

        [Test]

        public void Contains_QueueContains6_FalseReturned()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(-3);
            queue.Enqueue(-6);

            var flag = queue.Contains(6);

            Assert.IsFalse(flag);
        }

        [Test]

        public void Clear_ClearQueue_QueueIsEmpty()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(-2);

            queue.Clear();

            CollectionAssert.IsEmpty(queue);
        }

        [Test]

        public void CopyTo_CopyToNullArray_ShouldThrowArgumentNullException()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(-2);
            int[] array = null;

            Assert.Catch(typeof(ArgumentNullException), () => queue.CopyTo(array, 0));
        }

        [Test]

        public void CopyTo_CopyToArrayWithInvalidIndex_ShouldThrowArgumentOutOfRangeException()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(-2);
            int[] array = new int[2];

            Assert.Catch(typeof(ArgumentOutOfRangeException), () => queue.CopyTo(array, -1));
        }

        [Test]

        public void CopyTo_CopyToSmallArray_ShouldThrowArgumentException()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(-2);
            int[] array = new int[1];

            try
            {
                queue.CopyTo(array, 0);
            }
            catch (ArgumentException)
            {
                return;
            }

            Assert.Fail();
        }

        [Test]

        public void CopyTo_QueueSize2CopyToArraySize3Index2_ShouldThrowArgumentException()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(-2);
            int[] array = new int[3];

            try
            {
                queue.CopyTo(array, 2);
            }
            catch (ArgumentException)
            {
                return;
            }

            Assert.Fail();
        }

        [Test]

        public void CopyTo_QueueCopyToArrayWithTheSameSize_ArrayEqualQueue()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(-2);
            int[] array = new int[2];

            queue.CopyTo(array, 0);

            CollectionAssert.AreEqual(array, queue);
        }

        [Test]

        public void CopyTo_QueueCopyToLargerArray_ArrayIsSupersetOfQueue()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(-2);
            int[] array = new int[3];
            array[2] = 100;

            queue.CopyTo(array, 0);

            CollectionAssert.IsSupersetOf(array, queue);
        }

        [Test]

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

            Assert.Fail();
        }

        [Test]

        public void CopyTo_CopyToArrayClassWithInvalidIndex_ShouldThrowArgumentOutOfRangeException()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(-2);
            Array array = new int[2];

            Assert.Catch(typeof(ArgumentOutOfRangeException), ()=> queue.CopyTo(array, -1));
        }

        [Test]

        public void CopyTo_CopyToSmallArrayClass_ShouldThrowArgumentException()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(-2);
            Array array = new int[1];

            try
            {
                queue.CopyTo(array, 0);
            }
            catch (ArgumentException)
            {
                return;
            }

            Assert.Fail();
        }

        [Test]

        public void CopyTo_QueueSize2CopyToArrayClassSize3Index2_ShouldThrowArgumentException()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(-2);
            Array array = new int[3];

            try
            {
                queue.CopyTo(array, 2);
            }
            catch (ArgumentException)
            {
                return;
            }

            Assert.Fail();
        }

        [Test]

        public void CopyTo_QueueCopyToArrayClassWithTheSameSize_ArrayEqualQueue()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(-2);
            Array array = new int[2];

            queue.CopyTo(array, 0);

            CollectionAssert.AreEqual(array, queue);
        }

        [Test]

        public void CopyTo_QueueCopyToLargerArrayClass_ArrayIsSupersetOfQueue()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(-2);
            Array array = new int[3];
            array.SetValue(100, 2);

            queue.CopyTo(array, 0);

            CollectionAssert.IsSupersetOf(array, queue);
        }
    }
}