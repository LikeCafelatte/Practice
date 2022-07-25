using System;
using System.Linq;

public class Solution {
    public int solution(string[] strs,string t){
        int answer = -1;
        int[] count_arr = t.ToCharArray().Select(c => t.Length + 1).ToArray();
        for(int i = 0; i < t.Length; i++){
            for(int j = 0; j < strs.Length; j++){
                if(t.Substring(i, strs[j].Length).Equals(strs[j])){
                    if(i < strs[j].Length){
                        count_arr[i] = 1;
                    }else{
                        count_arr[i] = (count_arr[i] > 1 + count_arr[i - strs[j].Length] ? 1 + count_arr[i - strs[j].Length] : count_arr[i]);
                    }
                }
            }
        }
        answer = (count_arr.Max() > t.Length ? answer : count_arr.Max());
        return answer;
    }
 }
