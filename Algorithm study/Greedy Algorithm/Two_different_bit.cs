using System;

public class Solution {
    public long[] solution(long[] numbers) {
        long[] answer = new long[numbers.Length];
        for(int i = 0; i < numbers.Length; i++){
            long temp = numbers[i];
            int count = 1;
            while(temp > 0){
                if(temp % 2 == 0){
                    temp = temp/2;
                    for(int j = 0; j < count; j++){
                    temp *= 2;
                    if(j != 1) temp += 1;
                    }
                    break;
                }
                temp = temp/2;
                count++;
            }
            if(temp == 0){
                for(int j = 0; j < count; j++){
                    temp *= 2;
                    if(j != 1) temp += 1;
                }
            }
            answer[i] = temp;
        }
        return answer;
    }
}
