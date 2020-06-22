using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms.Uncategorized
{
    public class ReceiptError
    {

        public class Totals
        {
            int aSubtotal;
            int bSubtotal;
            int aTax;
            int bTax;
            int aTotal;
            int bTotal;

            public Totals(int aSubtotal, int bSubtotal, int aTax, int bTax, int aTotal, int bTotal)
            {
                this.aSubtotal = aSubtotal;
                this.bSubtotal = bSubtotal;
                this.aTax = aTax;
                this.bTax = bTax;
                this.aTotal = aTotal;
                this.bTotal = bTotal;
            }

            public bool Validate()
            {
                if(aSubtotal + aTax != aTotal)
                    return false;

                if(bSubtotal + bTax != bTotal)
                    return false;

                return true;
            }
        }

        List<(int,int)> GetPairs(int a , int b)
        {
            List<(int, int)> result = new List<(int, int)>();


            
            return result;
        }

        public static void Solution()
        {
            //float applePrice;
            //float pearPrice;
            //float strawberryPrice;

            //int aApple;
            //int bApple;
            //int aPear;
            //int bPear;
            //int aStrawberry;
            //int bStrawberry;


        }
    }
}
