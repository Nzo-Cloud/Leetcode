public class Solution {
    public int Score(string[] cards, char x) {
        var freqA = new int[26];
        var freqB = new int[26];
        int countA = 0, countB = 0, countXX = 0;
        
        foreach (var card in cards) {
            bool pos0 = card[0] == x, pos1 = card[1] == x;
            if (pos0 && pos1) countXX++;
            else if (pos0) { freqA[card[1] - 'a']++; countA++; }
            else if (pos1) { freqB[card[0] - 'a']++; countB++; }
        }
        
        int PairsFromGroup(int[] freq, int count, int wilds) {
            // "xx" cards can only pair WITH real cards, not with each other
            // So effective wilds limited to count (one wild per real card max)
            wilds = Math.Min(wilds, count);
            if (count == 0) return 0;
            int maxF = freq.Max();
            int total = count + wilds;
            return Math.Min(total / 2, total - maxF);
        }
        
        int result = 0;
        for (int ax = 0; ax <= countXX; ax++) {
            int bx = countXX - ax;
            int pairs = PairsFromGroup(freqA, countA, ax) + 
                        PairsFromGroup(freqB, countB, bx);
            result = Math.Max(result, pairs);
        }
        
        return result;
    }
}