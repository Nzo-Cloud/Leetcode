public class Solution {
    public int SumOfBeauties(int[] nums) {
        int n = nums.Length;

        int[] leftMax = new int[n];
        int[] rightMin = new int[n];

        // Build leftMax
        leftMax[0] = nums[0];
        for (int i = 1; i < n; i++) {
            leftMax[i] = Math.Max(leftMax[i - 1], nums[i]);
        }

        // Build rightMin
        rightMin[n - 1] = nums[n - 1];
        for (int i = n - 2; i >= 0; i--) {
            rightMin[i] = Math.Min(rightMin[i + 1], nums[i]);
        }

        int beautySum = 0;

        for (int i = 1; i < n - 1; i++) {
            if (leftMax[i - 1] < nums[i] && nums[i] < rightMin[i + 1]) {
                beautySum += 2;
            }
            else if (nums[i - 1] < nums[i] && nums[i] < nums[i + 1]) {
                beautySum += 1;
            }
        }

        return beautySum;
    }
}