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
                {'K', 70},
                {'L', 90},
                {'M', 15},
                {'N', 40},
                {'O', 10},
                {'P', 50},
                {'Q', 30},
                {'R', 50},
                {'S', 20},
                {'T', 20},
                {'U', 40},
                {'V', 50},
                {'W', 20},
                {'X', 17},
                {'Y', 20},
                {'Z', 21}
            };
            string groupOffer = "STXYZ";
            Dictionary<string, int> offers = new Dictionary<string, int>()
            {
                {"3A", 130},
                {"5A", 200},
                {"2B", 45},
                {"5H", 45},
                {"10H", 80},
                {"2K", 120},
                {"5P", 200},
                {"3Q", 80},
                {"2V", 90},
                {"3V", 130},
                {groupOffer, 45 }
            };
            int totalEItems = skusChar.Where(x => x.Equals('E')).Count();
            int totalNItems = skusChar.Where(x => x.Equals('N')).Count();
            int totalRItems = skusChar.Where(x => x.Equals('R')).Count();
            int totalAny3Items = 0;

            if (skusChar.Contains('Z'))
                totalAny3Items = skusChar.Where(x => x.Equals('Z')).Count();

            var nonGroupItems = 0;
            if (skusChar.Contains('X'))
                nonGroupItems = skusChar.Where(x => x.Equals('X')).Count();

            int totalGroupItem = 0;
            foreach (char skusItem in skusChar)
            {
                if (groupOffer.Contains(skusItem))
                {
                    totalGroupItem++;
                }
            }

            // apply group offer
            if (totalGroupItem % 3 == 0 || totalGroupItem > 3)
            {
                int multiplier = totalGroupItem / 3;
                totalPrice += offers[groupOffer] * multiplier;
            }
            else
            {

                foreach (char skusItem in skusChar)
                {
                    if (groupOffer.Contains(skusItem) && skusItem != 'Z')
                    {
                        totalAny3Items++;

                        if (skusItem == 'X' && skusChar.Length < 6)
                        {
                            totalPrice += items['X'] * nonGroupItems;
                        }
                        if (totalAny3Items > 3 && skusChar.Length < 6)
                            totalPrice += items[skusItem];
                    }

                    if (!items.ContainsKey(skusItem))
                        return -1;
                }
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
                                totalPrice += (offers["5A"] * multiplier);
                                totalAItems -= (5 * multiplier);
                            }
                            if (totalAItems % 3 == 0 || totalAItems > 3)
                            {
                                // offer: 3A for 130
                                int multiplier = totalAItems / 3;
                                totalPrice += (offers["3A"] * multiplier);
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
                                totalPrice += (offers["2B"] * multiplier);
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
                            if (totalHItems % 10 == 0 || totalHItems > 10)
                            {
                                // offer: 10H for 80 
                                int multiplier = totalHItems / 10;
                                totalPrice += (offers["10H"] * multiplier);
                                totalHItems -= (10 * multiplier);
                            }
                            if (totalHItems % 5 == 0 || totalHItems > 5)
                            {
                                // offer: 5H for 45
                                int multiplier = totalHItems / 5;
                                totalPrice += (offers["5H"] * multiplier);
                                totalHItems -= (5 * multiplier);
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
                            if (totalKItems % 2 == 0 || totalKItems > 2)
                            {
                                // offer: 2K for 150
                                int multiplier = totalKItems / 2;
                                totalPrice += (offers["2K"] * multiplier);
                                totalKItems -= (2 * multiplier);
                            }
                            if (totalKItems > 0)
                                totalPrice += items[item] * totalKItems;
                            continue;
                        case 'L':
                            int totalLItems = skusChar.Where(x => x.Equals(item)).Count();
                            totalPrice += items[item] * totalLItems;
                            continue;
                        case 'M':
                            int totalMItems = skusChar.Where(x => x.Equals(item)).Count();
                            if (totalNItems >= 3)
                            {
                                // offer: 3N get one M free
                                int multiplier = totalNItems / 3;
                                totalPrice += 0;
                                for (int i = 0; i < multiplier; i++)
                                {
                                    totalMItems--;
                                }
                            }
                            if (totalMItems > 0)
                                totalPrice += items[item] * totalMItems;
                            continue;
                        case 'N':
                            totalPrice += items[item] * totalNItems;
                            continue;
                        case 'O':
                            int totalOItems = skusChar.Where(x => x.Equals(item)).Count();
                            totalPrice += items[item] * totalOItems;
                            continue;
                        case 'P':
                            int totalPItems = skusChar.Where(x => x.Equals(item)).Count();
                            if (totalPItems % 5 == 0 || totalPItems > 5)
                            {
                                // offer: 5P for 200 
                                int multiplier = totalPItems / 5;
                                totalPrice += (offers["5P"] * multiplier);
                                totalPItems -= (5 * multiplier);
                            }
                            if (totalPItems > 0)
                                totalPrice += items[item] * totalPItems;
                            continue;
                        case 'Q':
                            int totalQItems = skusChar.Where(x => x.Equals(item)).Count();
                            // offer: 3R get one Q free
                            if (totalRItems >= 3)
                            {
                                // offer: 3N get one M free
                                int multiplier = totalRItems / 3;
                                totalPrice += 0;
                                for (int i = 0; i < multiplier; i++)
                                {
                                    totalQItems--;
                                }
                            }
                            if (totalQItems % 3 == 0 || totalQItems > 3)
                            {
                                // offer: 3Q for 80  
                                int multiplier = totalQItems / 3;
                                totalPrice += (offers["3Q"] * multiplier);
                                totalQItems -= (3 * multiplier);
                            }
                            if (totalQItems > 0)
                                totalPrice += items[item] * totalQItems;
                            continue;
                        case 'R':
                            totalPrice += items[item] * totalRItems;
                            continue;
                        case 'S':
                            int totalSItems = skusChar.Where(x => x.Equals(item)).Count();
                            if (totalAny3Items >= 3)
                                // already added as a group item
                                continue;

                            totalPrice += items[item] * totalSItems;
                            continue;
                        case 'T':
                            int totalTItems = skusChar.Where(x => x.Equals(item)).Count();
                            if (totalAny3Items >= 3)
                                // already added as a group item
                                continue;

                            totalPrice += items[item] * totalTItems;
                            continue;
                        case 'U':
                            int totalUItems = skusChar.Where(x => x.Equals(item)).Count();
                            // offer: 3U get one U free 
                            if (totalUItems >= 4)
                            {
                                int multiplier = totalUItems / 3;
                                totalPrice += 0;
                                for (int i = 0; i < multiplier; i++)
                                {
                                    totalUItems--;
                                }
                            }
                            if (totalUItems > 0)
                                totalPrice += items[item] * totalUItems;
                            continue;
                        case 'V':
                            int totalVItems = skusChar.Where(x => x.Equals(item)).Count();
                            if (totalVItems % 3 == 0 || totalVItems > 3)
                            {
                                // offer: 3V for 130
                                int multiplier = totalVItems / 3;
                                totalPrice += (offers["3V"] * multiplier);
                                totalVItems -= (3 * multiplier);
                            }
                            if (totalVItems % 2 == 0 || totalVItems > 2)
                            {
                                // offer: 2V for 90
                                int multiplier = totalVItems / 2;
                                totalPrice += (offers["2V"] * multiplier);
                                totalVItems -= (2 * multiplier);
                            }
                            if (totalVItems > 0)
                                totalPrice += items[item] * totalVItems;
                            continue;
                        case 'W':
                            int totalWItems = skusChar.Where(x => x.Equals(item)).Count();
                            totalPrice += items[item] * totalWItems;
                            continue;
                        case 'X':
                            int totalXItems = skusChar.Where(x => x.Equals(item)).Count();
                            if (totalAny3Items >= 3)
                                // already added as a group item
                                continue;

                            totalPrice += items[item] * totalXItems;
                            continue;
                        case 'Y':
                            int totalYItems = skusChar.Where(x => x.Equals(item)).Count();
                            if (totalAny3Items >= 3)
                                // already added as a group item
                                continue;

                            totalPrice += items[item] * totalYItems;
                            continue;
                        case 'Z':
                            int totalZItems = skusChar.Where(x => x.Equals(item)).Count();
                            if (totalAny3Items >= 3)
                                // already added as a group item
                                continue;

                            totalPrice += items[item] * totalZItems;
                            continue;
                        default:
                            return -1;
                    }
                }
            }
            return totalPrice;
        }
    }
}
