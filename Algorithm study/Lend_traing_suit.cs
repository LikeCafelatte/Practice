using System;

public class Solution {
    public int solution(int n, int[] lost, int[] reserve) {
        int answer = 0;
        int[] current = new int[n];
        for(int i = 0; i < lost.Length; i++){
            current[lost[i] - 1] -= 1;
        }
        for(int i = 0; i < reserve.Length; i++){
            current[reserve[i] - 1] += 1;
        }
        for(int i = 0; i < n; i++){
            if(current[i] == -1){
                if(i > 0 && current[i - 1] == 1){
                    current[i - 1] -= 1;
                    current[i] += 1;
                }else if(i < n-1 && current[i + 1] == 1){
                    current[i] += 1;
                    current[i + 1] -= 1;
                }
            }
            
            if(current[i] >= 0)
                answer++;
        }
        return answer;
    }
}