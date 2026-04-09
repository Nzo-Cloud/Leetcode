public class Solution {
    public string ToGoatLatin(string sentence) {
        string[] words = sentence.Split(' ');
        HashSet<char> vowels = new HashSet<char>{'a','e','i','o','u','A','E','I','O','U'};
        
        for (int i = 0; i < words.Length; i++) {
            string word = words[i];
            
            if (vowels.Contains(word[0])) {
                word = word + "ma";
            } else {
                word = word.Substring(1) + word[0] + "ma";
            }
            
            // add 'a' repeated (i + 1)
            word += new string('a', i + 1);
            
            words[i] = word;
        }
        
        return string.Join(" ", words);
    }
}