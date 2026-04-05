public class Solution {
    public int MinSubarray(int[] nums, int p) {
        long total = 0;
        foreach (int num in nums) {
            total += num;
        }

        int remainder = (int)(total % p);
        if (remainder == 0) return 0;

        Dictionary<int, int> map = new Dictionary<int, int>();
        map[0] = -1;

        long prefix = 0;
        int result = nums.Length;

        for (int i = 0; i < nums.Length; i++) {
            prefix = (prefix + nums[i]) % p;

            int target = (int)((prefix - remainder + p) % p);

            if (map.ContainsKey(target)) {
                result = Math.Min(result, i - map[target]);
            }

            // Update latest index
            map[(int)prefix] = i;
        }

        return result == nums.Length ? -1 : result;
    }
}