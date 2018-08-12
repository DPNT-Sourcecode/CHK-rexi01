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
            char EItem = 'E';

            using (StringReader sr = new StringReader(skus))
            {
                sr.Read(items, 0, skus.Length);
            }

            int totalAItems = items.Where(x => x.Equals(AItem)).Count();
            int totalBItems = items.Where(x => x.Equals(BItem)).Count();
            int totalEItems = items.Where(x => x.Equals(EItem)).Count();

            // calc total price of number of items
            foreach (char item in items.Distinct())
            {
                switch (item)
                {
                    case 'A':
                        if (totalAItems % 5 == 0)
                        {
                            // offer: 5A for 200
                            int multiplier = totalAItems / 5;
                            totalPrice += (200 * multiplier);
                            int totalA = totalAItems - (5 * multiplier);
                            totalPrice += 50 * totalA;
                        }
                        if (totalAItems % 3 == 0)
                        {
                            // offer: 3A for 130
                            int multiplier = totalAItems / 3;
                            totalPrice += (130 * multiplier);
                            int totalA = totalAItems - (3 * multiplier);
                            totalPrice += 50 * totalA;
                        }
                        if (totalAItems < 3 && totalAItems > 0)
                            totalPrice += 50 * totalAItems;
                        continue;
                    case 'B':
                        // offer: buy one get B free
                        if (totalEItems >= 1)
                        {
                            totalPrice += 0;
                            --totalBItems;
                        }
                        if (totalBItems % 2 == 0)
                        {
                            // offer : 2B for 45
                            int multiplier = totalBItems / 2;
                            totalPrice += (45 * multiplier);
                            int totalB = totalBItems - (2 * multiplier);
                            totalPrice += 30 * totalB;
                        }
                        if (totalBItems < 2 && totalBItems > 0)
                            totalPrice += 30 * totalBItems;
                        continue;
                    case 'C':
                        totalPrice += 20;
                        continue;
                    case 'D':
                        totalPrice += 15;
                        continue;
                    case 'E':
                        totalPrice += 40;
                        continue;
                    default:
                        return -1;
                }
            }
            return totalPrice;
        }
    }
}
