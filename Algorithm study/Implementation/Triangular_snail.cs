using System;

public class Solution {
    public int[] solution(int n) {
        int[] answer = new int[n * (n + 1) / 2];
        int count = 0;
        int position = 0;
        for(int i = 0; i < n; i++){
            for(int j = i; j < n; j++){
                switch(i % 3){
                    case 0:
                        position += j - i / 3;
                        break;
                    case 1:
                        position += 1;
                        break;
                    case 2:
                        position -= n + i - j - i / 3;
                        break;
                }
                answer[position] = ++count;
            }
        }
        return answer;
    }
}