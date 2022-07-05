using System;

public class Solution {
    public int solution(int[] d, int budget) {
        int answer = 0;
        int portioned_budget = 0;
        Array.Sort(d);
        for(int i = 0; i < d.Length; i++){
            if(d[i] + portioned_budget > budget) break;
            portioned_budget += d[i];
            answer++;
        }
        return answer;
    }
}