public class Solution {
    public int LargestPerimeter(int[] nums) {
        Array.Sort(nums);
        
        for (int i = nums.Length - 1; i >= 2; i--) {
            int a = nums[i - 2];
            int b = nums[i - 1];
            int c = nums[i];
            
            if (a + b > c) {
                return a + b + c;
            }
        }
        
        return 0;
    }
}