using System.Collections.Generic;
using System.Linq;
using RashkouProject.Game;

namespace RashkouProject.Mathematics
{
    public class BinaryHeap
    {
        public List<Recovery> List = new List<Recovery>();

        public int HeapSize()
        {
            return List.Count;
        }

        public void Add(Recovery recovery)
        {
            List.Add(recovery);
            int i = HeapSize() - 1;
            int parent = (i - 1) / 2;

            while (i > 0 && List[parent].Time > List[i].Time)
            {
                Recovery temp = List[i];
                List[i] = List[parent];
                List[parent] = temp;

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

                if (leftChild < HeapSize() && List[leftChild].Time < List[smallestChild].Time)
                {
                    smallestChild = leftChild;
                }

                if (rightChild < HeapSize() && List[rightChild].Time < List[smallestChild].Time)
                {
                    smallestChild = rightChild;
                }

                if (smallestChild == i)
                {
                    break;
                }

                Recovery temp = List[i];
                List[i] = List[smallestChild];
                List[smallestChild] = temp;
                i = smallestChild;
            }
        }

        public Recovery GetMin()
        {
            Recovery result = List[0];
            List[0] = List[HeapSize() - 1];
            List.RemoveAt(HeapSize() - 1);
            Heapify(0);
            return result;
        }

    }
}