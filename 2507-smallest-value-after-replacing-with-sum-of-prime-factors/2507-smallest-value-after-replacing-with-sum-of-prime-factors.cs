public class Solution {
    public int SmallestValue(int n) {
        while (true) {
            int sum = PrimeFactorSum(n);

            // Stop when the value no longer decreases
            if (sum == n)
                return n;

            n = sum;
        }
    }

    private int PrimeFactorSum(int n) {
        int sum = 0;

        // Factor out 2s
        while (n % 2 == 0) {
            sum += 2;
            n /= 2;
        }

        // Factor odd numbers
        for (int i = 3; i * i <= n; i += 2) {
            while (n % i == 0) {
                sum += i;
                n /= i;
            }
        }

        // Remaining prime factor
        if (n > 1)
            sum += n;

        return sum;
    }
}