public class Solution {
    public IList<bool> CanMakePaliQueries(string s, int[][] queries) {
        int n = s.Length;

        // prefix[i] = parity mask for s[0..i-1]
        int[] prefix = new int[n + 1];

        for (int i = 0; i < n; i++) {
            int bit = 1 << (s[i] - 'a');
            prefix[i + 1] = prefix[i] ^ bit;
        }

        List<bool> answer = new List<bool>();

        foreach (var q in queries) {
            int left = q[0];
            int right = q[1];
            int k = q[2];

            // odd/even parity mask for substring
            int mask = prefix[right + 1] ^ prefix[left];

            // count odd frequency chars
            int oddCount = BitOperations.PopCount((uint)mask);

            // each replacement fixes 2 odd chars
            answer.Add(oddCount / 2 <= k);
        }

        return answer;
    }
}