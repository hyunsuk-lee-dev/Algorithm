using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Functions
{

    public enum CompareType
    {
        Ascending,
        Descending
    }

    public class ArrayComparer<T> : IComparer<T[]> where T : IComparable
    {
        public int index;

        public ArrayComparer(int index)
        {
            this.index = index;
        }

        public int Compare(T[] x, T[] y)
        {
            if(x.Length > index && y.Length > index)
                return x[index].CompareTo(y[index]);
            else
                return 0;
        }
    }

}
