using System;

class Solution
{
    public int[] solution(int n, string[] words)
    {
        string backup = "";
        for(int i = 0; i < words.Length; i++){
            if(backup.Length > 0 && !backup[backup.Length - 1].Equals(words[i][0])) return new int[]{(i % n) + 1, (i / n) + 1};
            if(Array.IndexOf(words, words[i]) != i) return new int[]{(i % n) + 1, (i / n) + 1};
            backup = words[i];
        }
        
        return new int[] {0, 0};
    }
}