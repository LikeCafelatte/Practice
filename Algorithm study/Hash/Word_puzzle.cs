using System;
using System.Linq;
using System.Collections.Generic;

public class Solution {
    int answer = -1;
    Dictionary<string, bool> dict_strs = new Dictionary<string, bool>();
    public int solution(string[] strs,string t){
        dict_strs = strs.ToDictionary(s => s, s => true);
        Sol(t, 0, 1);
        
        return answer;
    }
    
    public void Sol(string t, int start, int current){
        for(int i = 1; i <= (5 > t.Length - start ? t.Length - start : 5); i++){
            string str = t.Substring(start, i);
            if(dict_strs.ContainsKey(str)){
                if(start + str.Length == t.Length){
                    if(answer == -1 || answer > current) answer = current;
                    return;
                }
                Sol(t, start + str.Length, current + 1);
            }
        }
    }
 }