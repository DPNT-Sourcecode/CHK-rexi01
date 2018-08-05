using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static int Checkout(string skus)
        {
            int totalPrice = 0;
            char[] items = new char[skus.Length];
            char AItem = 'A';
            char BItem = 'B';

            using (StringReader sr = new StringReader(skus))
            {
                sr.Read(items, 0, skus.Length);
            }

            int totalAItems = items.Where(x => x.Equals(AItem)).Count();
            int totalBItems = items.Where(x => x.Equals(BItem)).Count();

            while (totalAItems % 2 == 0)
            {
                if (totalAItems >= 3)
                    totalPrice += 130;
                else
                    totalPrice += 50;
            }

            if (totalBItems >= 2)
            {
                totalPrice += 45;
                totalPrice += (30 * (totalAItems - 2));
            }

            // calc total price of number of items
            foreach (char item in items)
            {
                switch (item)
                {
                    case 'A':
                        if (totalAItems < 3)
                            totalPrice += 50;
                        continue;
                    case 'B':
                        if (totalAItems < 2)
                            totalPrice += 30;
                        continue;
                    case 'C':
                        totalPrice += 20;
                        continue;
                    case 'D':
                        totalPrice += 15;
                        continue;
                    default:
                        return -1;
                        //throw new System.ArgumentException("Invalid item");
                }
            }
            return totalPrice;
        }
    }
}
