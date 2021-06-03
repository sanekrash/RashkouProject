using System.Collections.Generic;
using System.Linq;
using RashkouProject.Game;

namespace RashkouProject.Mathematics
{
    public class BinaryHeap
    {
        private List<Recovery> list = new List<Recovery>();

        public int HeapSize()
        {
            return list.Count;
        }

        public void Add(Recovery recovery)
        {
            list.Add(recovery);
            int i = HeapSize() - 1;
            int parent = (i - 1) / 2;

            while (i > 0 && list[parent].Time > list[i].Time)
            {
                Recovery temp = list[i];
                list[i] = list[parent];
                list[parent] = temp;

                i = parent;
                parent = (i - 1) / 2;
            }
        }

        public void Heapify(int i)
        {
            int leftChild;
            int rightChild;
            int smallestChild;

            for (;;)
            {
                leftChild = 2 * i + 1;
                rightChild = 2 * i + 2;
                smallestChild = i;

                if (leftChild < HeapSize() && list[leftChild].Time < list[smallestChild].Time)
                {
                    smallestChild = leftChild;
                }

                if (rightChild < HeapSize() && list[rightChild].Time < list[smallestChild].Time)
                {
                    smallestChild = rightChild;
                }

                if (smallestChild == i)
                {
                    break;
                }

                Recovery temp = list[i];
                list[i] = list[smallestChild];
                list[smallestChild] = temp;
                i = smallestChild;
            }
        }

        public Recovery GetMin()
        {
            Recovery result = list[0];
            list[0] = list[HeapSize() - 1];
            list.RemoveAt(HeapSize() - 1);
            Heapify(0);
            return result;
        }
    }
}