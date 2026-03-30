public class Solution {
    public void MoveZeroes(int[] nums) {
        int insertPos = 0;

        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] != 0) {
                // Swap current element with insert position
                int temp = nums[insertPos];
                nums[insertPos] = nums[i];
                nums[i] = temp;

                insertPos++;
            }
        }
    }
}