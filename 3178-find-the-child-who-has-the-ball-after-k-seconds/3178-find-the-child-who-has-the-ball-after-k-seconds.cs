public class Solution {
    public int NumberOfChild(int n, int k) {
        int cycle = 2 * (n - 1);
        k %= cycle;

        if (k <= n - 1) {
            return k;
        } else {
            return 2 * (n - 1) - k;
        }
    }
}