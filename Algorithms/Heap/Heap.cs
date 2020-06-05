using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms.Heap
{
    public enum HeapType
    {
        Max,
        Min
    }

    public class Heap<T> where T : IComparable
    {
        public HeapType heapType;

        private List<T> list = new List<T>();

        public int Count { get => list.Count; }

        public Heap(HeapType heapType)
        {
            this.heapType = heapType;
            list = new List<T>();
        }

        public void Add(T item)
        {
            list.Add(item);

            int i = list.Count - 1;
            while(i > 0)
            {
                int parent = (i - 1) / 2;

                if(heapType == HeapType.Max ? list[parent].CompareTo(list[i]) < 0 : list[parent].CompareTo(list[i]) > 0)
                {
                    Swap(parent, i);
                    i = parent;
                }
                else
                    break;
            }
        }
        
        public T Remove()
        {
            if(list.Count <= 0)
                throw new ArgumentOutOfRangeException("", "인덱스가 범위를 벗어났습니다.인덱스는 음수가 아니어야 하며 컬렉션의 크기 보다 작아야 합니다.");

            T root = list[0];


           
            list[0] = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);

            int i = 0;
            int last = list.Count - 1;

            while(i < last)
            {
                int child = i * 2 + 1;

                if(child < last && (heapType == HeapType.Max ? list[child].CompareTo(list[child + 1]) < 0 : list[child].CompareTo(list[child + 1]) > 0))
                    child++;

                if(child > last || (heapType == HeapType.Max ? list[i].CompareTo(list[child]) >= 0 : list[i].CompareTo(list[child]) <= 0))
                    break;

                Swap(i, child);
                i = child;
            }

            return root;
        }

        public T Peek() => list[0];

        private void Swap(int a, int b)
        {
            T temp = list[a];
            list[a] = list[b];
            list[b] = temp;
        }
    }
}
