using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Functions
{
    public class StringArrayComparer : IComparer<string[]>
    {
        public int index;

        public StringArrayComparer(int index)
        {
            this.index = index;
        }

        public int Compare(string[] x, string[] y)
        {
            if(x.Length > index && y.Length > index)
                return x[index].CompareTo(y[index]);
            else
                return 0;
        }
    }

}
