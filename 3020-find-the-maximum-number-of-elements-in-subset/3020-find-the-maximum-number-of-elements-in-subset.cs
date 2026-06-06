public class Solution {
    public int MaximumLength(int[] nums) {
        var freq = new Dictionary<long, int>();
        foreach (int n in nums)
            freq[n] = freq.GetValueOrDefault(n) + 1;

        int ans = 1;

        if (freq.TryGetValue(1, out int ones)) {
            int count = ones % 2 == 0 ? ones - 1 : ones;
            ans = Math.Max(ans, count);
        }

        foreach (long x in freq.Keys) {
            if (x == 1) continue;

            int count = 0;
            long cur = x;

            while (freq.TryGetValue(cur, out int c) && c >= 2) {
                count += 2;
                cur = cur * cur;
            }

            if (freq.ContainsKey(cur))
                count += 1;          // valid middle found → odd total ✓
            else if (count > 0)
                count -= 1;          // no middle → drop last pair, use it as middle instead

            ans = Math.Max(ans, count);
        }

        return ans;
    }
}