using System.Collections.Generic;
using System.Linq;
using RashkouProject.Game;

namespace RashkouProject.Mathematics
{
    public class BinaryHeap<T>
    {
        internal List<Node> Nodes = new List<Node>();

        public class Node
        {
            private BinaryHeap<T> _heap;
            internal int _index;
            internal int Priority;
            public T Data;
            

            public Node(T data, int priority, int index, BinaryHeap<T> heap)
            {
                Data = data;
                Priority = priority;
                _index = index;
                _heap = heap;
            }
            public void UpdatePriority()
            {
                int leftChild;
                int rightChild;
                int smallestChild;

                for (;;)
                {
                    leftChild = 2 * _index + 1;
                    rightChild = 2 * _index + 2;
                    smallestChild = _index;

                    if (leftChild < _heap.HeapSize() &&
                        _heap.Nodes[leftChild].Priority < _heap.Nodes[smallestChild].Priority)
                        smallestChild = leftChild;
                    if (rightChild < _heap.HeapSize() &&
                        _heap.Nodes[rightChild].Priority < _heap.Nodes[smallestChild].Priority)
                        smallestChild = rightChild;
                    if (smallestChild == _index)
                        break;
                    Node temp = _heap.Nodes[_index];
                    _heap.Nodes[_index] = _heap.Nodes[smallestChild];
                    _heap.Nodes[_index]._index = temp._index;
                    _heap.Nodes[smallestChild] = temp;
                    _heap.Nodes[smallestChild]._index = smallestChild;
                }

            }

            public void Remove()
            {
                _heap.Nodes[_index] = _heap.Nodes[_heap.HeapSize() - 1];
                _heap.Nodes[_index]._index = _index;
                if (_heap.HeapSize() > 0) 
                    _heap.Nodes[_index].UpdatePriority();
                _heap.Nodes.RemoveAt(_heap.HeapSize() - 1);
            }


        }

        public Node Add(T data, int priority)
        {
            int i = HeapSize();
            int parent = (i - 1) / 2;
            Nodes.Add(new Node(data, priority, i, this));
            while (i > 0 && Nodes[parent].Priority > Nodes[i].Priority)
            {
                Node temp = Nodes[i];
                Nodes[i] = Nodes[parent];
                Nodes[i]._index = temp._index;
                Nodes[parent] = temp;
                Nodes[parent]._index = parent;
                i = parent;
                parent = (i - 1) / 2;
            }

            return Nodes[i];
        }
        public int HeapSize() => Nodes.Count;
        public Node GetMin() => Nodes[0];

    }
}
