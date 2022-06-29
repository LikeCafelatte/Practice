using System;
using System.Collections.Generic;

class Solution {
    public int solution(int[,] maps) {
        bool[,] isDetected = new bool[maps.GetLength(0), maps.GetLength(1)];
        Queue<int[]> q = new Queue<int[]>();
        
        q.Enqueue(new int[] {0, 0, 1});
        
        for(int i = 0; i < maps.GetLength(0); i++) {
            for(int j = 0; j < maps.GetLength(1); j++) {
                if(maps[i, j] == 0) isDetected[i, j] = true;
                else isDetected[i, j] = false;
            }
        }
        
        while(q.Count > 0){
            int[] input = q.Dequeue();
            
            if(input[0] < 0 || input[0] >= maps.GetLength(0) || input[1] < 0 || input[1] >= maps.GetLength(1)) continue;
            if(isDetected[input[0], input[1]]) continue;
            
            if(input[0] == maps.GetLength(0) - 1 && input[1] == maps.GetLength(1) - 1) return input[2];
            isDetected[input[0], input[1]] = true;
            
            q.Enqueue(new int[] {input[0] - 1, input[1], input[2] + 1});
            q.Enqueue(new int[] {input[0] + 1, input[1], input[2] + 1});
            q.Enqueue(new int[] {input[0], input[1] - 1, input[2] + 1});
            q.Enqueue(new int[] {input[0], input[1] + 1, input[2] + 1});
        }
        
        return -1;
    }
}