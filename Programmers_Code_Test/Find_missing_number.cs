using System;

public class Solution {
    public int solution(int[] numbers) {
        int answer = 45; // 0 ~ 9 summation
        
        foreach(int n in numbers){
            answer -= n;
        }
        
        return answer;
    }
}