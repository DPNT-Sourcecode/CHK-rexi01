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
                        if (totalAItems % 5 == 0 || totalAItems > 5)
                        {
                            // offer: 5A for 200
                            int multiplier = totalAItems / 5;
                            totalPrice += (200 * multiplier);
                            totalAItems -= (5 * multiplier);
                        }
                        if (totalAItems % 3 == 0 || totalAItems > 3)
                        {
                            // offer: 3A for 130
                            int multiplier = totalAItems / 3;
                            totalPrice += (130 * multiplier);
                            totalAItems -= (3 * multiplier);
                        }
                        if (totalAItems > 0)
                            totalPrice += 50 * totalAItems;
                        continue;
                    case 'B':
                        // offer: buy one get B free
                        if (totalEItems >= 2)
                        {
                            int multiplier = totalEItems / 2;
                            totalPrice += 0;
                            for (int i=0; i<multiplier; i++)
                            {
                                totalBItems--;
                            }
                        }
                        if (totalBItems % 2 == 0 || totalBItems > 2)
                        {
                            // offer : 2B for 45
                            int multiplier = totalBItems / 2;
                            totalPrice += (45 * multiplier);
                            totalBItems -= 2 * multiplier;
                        }
                        if (totalBItems > 0)
                            totalPrice += 30 * totalBItems;
                        continue;
                    case 'C':
                        totalPrice += 20;
                        continue;
                    case 'D':
                        totalPrice += 15;
                        continue;
                    case 'E':
                        totalPrice += 40 * totalEItems;
                        continue;
                    default:
                        return -1;
                }
            }
            return totalPrice;
        }
    }
}
