public class Solution {
    public int MaxLevelSum(TreeNode root) {
        int bestLevel = 1;
        long bestSum = long.MinValue;
        int level = 0;
        
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while (queue.Count > 0) {
            level++;
            int size = queue.Count;
            long sum = 0;
            
            for (int i = 0; i < size; i++) {
                var node = queue.Dequeue();
                sum += node.val;
                if (node.left != null)  queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
            
            if (sum > bestSum) {
                bestSum = sum;
                bestLevel = level;
            }
        }
        
        return bestLevel;
    }
}