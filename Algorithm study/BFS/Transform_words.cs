using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(string begin, string target, string[] words) {
        // target이 포함되지 않거나, begin에서 변환이 불가능한 경우 0 리턴
        if(!words.Contains(target)) return 0;
        bool isPossible = false;
        foreach(string word in words){
            if(isLinked(begin, word)) isPossible = true;
        }
        if(!isPossible) return 0;

        // BFS 탐색
        int[] distances = new int[words.Length];
        Queue<KeyValuePair<string, int>> q = new Queue<KeyValuePair<string, int>>();
        q.Enqueue(new KeyValuePair<string, int>(begin, 0));
        while(q.Count > 0){
            KeyValuePair<string, int> dq = q.Dequeue();
            if(!words.Contains(dq.Key)){
                for(int i = 0; i < words.Length; i++){
                    if(isLinked(dq.Key, words[i]))
                        q.Enqueue(new KeyValuePair<string, int>(words[i], dq.Value + 1));
                }
                continue;
            }

            if(distances[Array.IndexOf(words,dq.Key)] > 0) continue;
            distances[Array.IndexOf(words,dq.Key)] = dq.Value;
            if(dq.Key.Equals(target)) return dq.Value;
            for(int i = 0; i < words.Length; i++){
                if(distances[i] > 0) continue;
                if(isLinked(dq.Key, words[i]))
                    q.Enqueue(new KeyValuePair<string, int>(words[i], dq.Value + 1));
            }

        }
        return 0;
    }

    // 변환 가능한지 확인
    public bool isLinked(string word, string str){
        char[] temp_word = word.ToCharArray();
        char[] temp_str = str.ToCharArray();
        int count = 0;
        for(int i = 0; i < word.Length; i++){
            if(temp_word[i] == temp_str[i])
                count++;
        }
        if(count == word.Length - 1) return true;
        return false;
    }
}