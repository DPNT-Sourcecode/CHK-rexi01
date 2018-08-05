namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static int Checkout(string skus)
        {
            int totalPrice = 0;
            string[] items = skus.Split(',');
            int totalAItems = 0;
            int totalBItems = 0;

            // calc total price of number of items
            foreach (string item in items)
            {
                switch (item)
                {
                    case "A":
                        totalAItems++;
                        totalPrice += totalAItems == 3 ? 130 : 50;
                        continue;
                    case "B":
                        totalBItems++;
                        totalPrice += totalBItems == 2 ? 45 : 30;
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
