using System;

public class Solution {
    public int[] solution(int[] array, int[,] commands) {
        int[] answer = new int[commands.Length/3];

        for(int i = 0; i < commands.Length/3; i++){
            int startIdx = commands[i, 0] - 1;
            int length = commands[i, 1] - commands[i, 0] + 1;
            int[] temp_array = new int[length];
            Array.Copy(array, startIdx, temp_array, 0, length);

            Array.Sort(temp_array);

            answer[i] = temp_array[commands[i, 2] - 1];
        }
        return answer;
    }
}