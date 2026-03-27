public class Solution {
    public double MyPow(double x, int n) {
        long N = n;
        
        // Handle negative powers
        if (N < 0) {
            x = 1 / x;
            N = -N;
        }
        
        double result = 1.0;
        
        while (N > 0) {
            // If N is odd, multiply result
            if ((N & 1) == 1) {
                result *= x;
            }
            
            // Square x and halve N
            x *= x;
            N >>= 1;
        }
        
        return result;
    }
}