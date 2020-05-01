using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonOnlineAssessment.DataStructure
{
    public class QueueItem
    {
        public int Priority { get; }
        public object Value { get; }

        public QueueItem(object value, int priority)
        {
            Priority = priority;
            Value = value;
        }
    }

    public class PriorityQueue<T> where T : QueueItem
    {
        private List<T> _queue;
        private bool _minHeap = false;
        public int Size  { get => _queue.Count; }

        public PriorityQueue(bool minHeap = false)
        {
            _minHeap = minHeap;
            this._queue = new List<T>();
        }

        public void Enqueue(T item)
        {
            _queue.Add(item);

            if(Size > 1)
            {
                Heapify();
            }
        }

        public T Dequeue()
        {
            if(Size > 0)
            {
                T firstValue = _queue[0];
                _queue.RemoveAt(0);
                Heapify();
                return firstValue;
            }

            return default(T);
        }

        public T Peek()
        {
            if (Size > 0)
            {
                T firstValue = _queue[0];
                return firstValue;
            }

            return default(T);
        }
            public void Heapify()
        {
            int size = _queue.Count;
            for (int parentIndex = size / 2; parentIndex >= 0; parentIndex--)
            {
                if (_minHeap)
                {
                    MinHeap(parentIndex);
                }
                else
                {
                    MaxHeap(parentIndex);
                }
            }
        }

        public void MinHeap(int parentIndex)
        {
            int size = _queue.Count;

            int leftChildIndex = parentIndex * 2 + 1;
            int rightChildIndex = parentIndex * 2 + 2;

            int minIndex = parentIndex;

            if (leftChildIndex >= 0 && leftChildIndex < size &&
                _queue[leftChildIndex].Priority < _queue[minIndex].Priority)
            {
                minIndex = leftChildIndex;
            }

            if (rightChildIndex >= 0 && rightChildIndex < size &&
                _queue[rightChildIndex].Priority < _queue[minIndex].Priority)
            {
                minIndex = rightChildIndex;
            }

            if (minIndex != parentIndex)
            {
                Swap(minIndex, parentIndex);
                MinHeap(minIndex);
            }
        }

        public void MaxHeap(int parentIndex)
        {
            int size = _queue.Count;

            int leftChildIndex = parentIndex * 2 + 1;
            int rightChildIndex = parentIndex * 2 + 2;

            int maxIndex = parentIndex;

            if (leftChildIndex >= 0 && leftChildIndex < size &&
                _queue[leftChildIndex].Priority > _queue[maxIndex].Priority)
            {
                maxIndex = leftChildIndex;
            }

            if (rightChildIndex >= 0 && rightChildIndex < size &&
                _queue[rightChildIndex].Priority > _queue[maxIndex].Priority)
            {
                maxIndex = rightChildIndex;
            }

            if (maxIndex != parentIndex)
            {
                Swap(maxIndex, parentIndex);
                MaxHeap(maxIndex);
            }
        }

        private void Swap(int source, int target)
        {
            T temp = _queue[source];
            _queue[source] = _queue[target];
            _queue[target] = temp;
        }
    }
}
