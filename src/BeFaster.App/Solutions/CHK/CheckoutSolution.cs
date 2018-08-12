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
            char[] skusChar = skus.ToCharArray();
            Dictionary<char, int> items = new Dictionary<char, int>()
            {
                {'A', 50},
                {'B', 30},
                {'C', 20},
                {'D', 15},
                {'E', 40},
                {'F', 10},
                {'G', 20},
                {'H', 10},
                {'I', 35},
                {'J', 60},
                {'K', 80},
                {'L', 90},
                {'M', 15},
                {'N', 40},
                {'O', 10},
                {'P', 50},
                {'Q', 30},
                {'R', 50},
                {'S', 30},
                {'T', 20},
                {'U', 40},
                {'V', 50},
                {'W', 20},
                {'X', 90},
                {'Y', 10},
                {'Z', 50}
            };
            int totalEItems = skusChar.Where(x => x.Equals('E')).Count();

            // calc total price of number of items
            foreach (char item in items.Keys)
            {
                switch (item)
                {
                    case 'A':
                        int totalAItems = skusChar.Where(x => x.Equals(item)).Count();
                        if (totalAItems % 5 == 0 || totalAItems > 5)
                        {
                            // offer: 5A for 200
                            int multiplier = totalAItems / 5;
                            totalPrice += (items[item] * multiplier);
                            totalAItems -= (5 * multiplier);
                        }
                        if (totalAItems % 3 == 0 || totalAItems > 3)
                        {
                            // offer: 3A for 130
                            int multiplier = totalAItems / 3;
                            totalPrice += (items[item] * multiplier);
                            totalAItems -= (3 * multiplier);
                        }
                        if (totalAItems > 0)
                            totalPrice += items[item] * totalAItems;
                        continue;
                    case 'B':
                        int totalBItems = skusChar.Where(x => x.Equals(item)).Count();
                        // offer: buy one get B free
                        if (totalEItems >= 2)
                        {
                            int multiplier = totalEItems / 2;
                            totalPrice += 0;
                            for (int i = 0; i < multiplier; i++)
                            {
                                totalBItems--;
                            }
                        }
                        if (totalBItems % 2 == 0 || totalBItems > 2)
                        {
                            // offer : 2B for 45
                            int multiplier = totalBItems / 2;
                            totalPrice += (items[item] * multiplier);
                            totalBItems -= 2 * multiplier;
                        }
                        if (totalBItems > 0)
                            totalPrice += items[item] * totalBItems;
                        continue;
                    case 'C':
                        int totalCItems = skusChar.Where(x => x.Equals(item)).Count();
                        totalPrice += items[item] * totalCItems;
                        continue;
                    case 'D':
                        int totalDItems = skusChar.Where(x => x.Equals(item)).Count();
                        totalPrice += items[item] * totalDItems;
                        continue;
                    case 'E':
                        totalPrice += items[item] * totalEItems;
                        continue;
                    case 'F':
                        int totalFItems = skusChar.Where(x => x.Equals(item)).Count();
                        // offer: buy 2Fs and get another F free
                        if (totalFItems >= 3)
                        {
                            int multiplier = totalFItems / 3;
                            totalPrice += 0;
                            for (int i = 0; i < multiplier; i++)
                            {
                                totalFItems--;
                            }
                        }
                        if (totalFItems > 0)
                            totalPrice += 10 * totalFItems;
                        continue;
                    case 'G':
                        int totalGItems = skusChar.Where(x => x.Equals(item)).Count();
                        totalPrice += items[item] * totalGItems;
                        continue;
                    case 'H':
                        int totalHItems = skusChar.Where(x => x.Equals(item)).Count();
                        // offer: 5H for 45, 10H for 80 
                        if(totalHItems % 5 == 0 || totalHItems > 5)
                        {
                            // offer: 5H for 45
                            int multiplier = totalHItems / 5;
                            totalPrice += (items[item] * multiplier);
                            totalHItems -= (5 * multiplier);
                        }
                        if (totalHItems % 10 == 0 || totalHItems > 10)
                        {
                            // offer: 10H for 80 
                            int multiplier = totalHItems / 10;
                            totalPrice += (items[item] * multiplier);
                            totalHItems -= (10 * multiplier);
                        }
                        if (totalHItems > 0)
                            totalPrice += items[item] * totalHItems;
                        continue;
                    case 'I':
                        int totalIItems = skusChar.Where(x => x.Equals(item)).Count();
                        totalPrice += items[item] * totalIItems;
                        continue;
                    case 'J':
                        int totalJItems = skusChar.Where(x => x.Equals(item)).Count();
                        totalPrice += items[item] * totalJItems;
                        continue;
                    case 'K':
                        int totalKItems = skusChar.Where(x => x.Equals(item)).Count();
                        totalPrice += items[item] * totalKItems;
                        continue;
                    case 'L':
                        int totalLItems = skusChar.Where(x => x.Equals(item)).Count();
                        totalPrice += items[item] * totalLItems;
                        continue;
                    case 'M':
                        int totalMItems = skusChar.Where(x => x.Equals(item)).Count();
                        totalPrice += items[item] * totalMItems;
                        continue;
                    case 'N':
                        int totalNItems = skusChar.Where(x => x.Equals(item)).Count();
                        totalPrice += items[item] * totalNItems;
                        continue;
                    case 'O':
                        int totalOItems = skusChar.Where(x => x.Equals(item)).Count();
                        totalPrice += items[item] * totalOItems;
                        continue;
                    case 'P':
                        int totalPItems = skusChar.Where(x => x.Equals(item)).Count();
                        totalPrice += items[item] * totalPItems;
                        continue;
                    case 'Q':
                        int totalQItems = skusChar.Where(x => x.Equals(item)).Count();
                        totalPrice += items[item] * totalQItems;
                        continue;
                    case 'R':
                        int totalRItems = skusChar.Where(x => x.Equals(item)).Count();
                        totalPrice += items[item] * totalRItems;
                        continue;
                    case 'S':
                        int totalSItems = skusChar.Where(x => x.Equals(item)).Count();
                        totalPrice += items[item] * totalSItems;
                        continue;
                    case 'T':
                        int totalTItems = skusChar.Where(x => x.Equals(item)).Count();
                        totalPrice += items[item] * totalTItems;
                        continue;
                    case 'U':
                        int totalUItems = skusChar.Where(x => x.Equals(item)).Count();
                        totalPrice += items[item] * totalUItems;
                        continue;
                    case 'V':
                        int totalVItems = skusChar.Where(x => x.Equals(item)).Count();
                        totalPrice += items[item] * totalVItems;
                        continue;
                    case 'W':
                        int totalWItems = skusChar.Where(x => x.Equals(item)).Count();
                        totalPrice += items[item] * totalWItems;
                        continue;
                    case 'X':
                        int totalXItems = skusChar.Where(x => x.Equals(item)).Count();
                        totalPrice += items[item] * totalXItems;
                        continue;
                    case 'Y':
                        int totalYItems = skusChar.Where(x => x.Equals(item)).Count();
                        totalPrice += items[item] * totalYItems;
                        continue;
                    case 'Z':
                        int totalZItems = skusChar.Where(x => x.Equals(item)).Count();
                        totalPrice += items[item] * totalZItems;
                        continue;
                    default:
                        return -1;
                }
            }
            return totalPrice;
        }
    }
}
