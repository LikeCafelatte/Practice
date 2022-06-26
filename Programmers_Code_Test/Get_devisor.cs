using System;

public class Solution {
    public int solution(int left, int right) {
        int answer = 0;
        for(int i = left; i <= right; i++){
            if(GetDevisorCount(i) % 2 == 0) answer += i;
            else answer -= i;
        }
        return answer;
    }
    public int GetDevisorCount(int num){
        if(num == 1) return 1;
        if(num == 2 || num == 3) return 2;
        if(num == 4) return 3;
        int count = 0;
        for(int i = 1; i <= num; i++){
            if(num % i == 0) count++;
        }
        return count;
    }
}