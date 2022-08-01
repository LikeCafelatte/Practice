using System;
using System.Collections.Generic;

public class Solution {
    public int solution(string[,] clothes) {
        int answer = 1;
        Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
        for(int i = 0; i < clothes.GetLength(0); i++){
            if(dictionary.ContainsKey(clothes[i, 1])){
                dictionary[clothes[i, 1]].Add(clothes[i, 0]);
            }else{
                List<string> new_list = new List<string>();
                new_list.Add(clothes[i, 0]);
                dictionary.Add(clothes[i, 1], new_list);
            }
        }
        foreach(List<string> list in dictionary.Values){
            answer *= list.Count + 1;
        }
        return answer - 1;
    }
}