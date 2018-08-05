using System.Collections.Generic;
using System.Linq;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static int Checkout(string skus)
        {
            int totalPrice = 0;
            IList<string> items = skus.Split(',');
            int totalAItems = items.Where(x => x.Equals("A")).Count();
            int totalBItems = items.Where(x => x.Equals("B")).Count();
            IEnumerable<string> itemsDistinct = items.Distinct();

            if (totalAItems == 3)
            {
                totalPrice += 130;
                items.Remove("A");
            }

            if (totalBItems == 2)
            {
                totalPrice += 45;
                items.Remove("B");
            }

            // calc total price of number of items
            foreach (string item in items)
            {
                switch (item)
                {
                    case "A":
                        totalPrice += 50;
                        continue;
                    case "B":
                        totalPrice += 30;
                        continue;
                    case "C":
                        totalPrice += 20;
                        continue;
                    case "D":
                        totalPrice += 15;
                        continue;
                    default:
                        return 0;
                }
            }
            return totalPrice;
        }
    }
}
