using System;

public class Solution {
    public int[] solution(int rows, int columns, int[,] queries) {
        int[] answer = new int[queries.GetLength(0)];
        int[,] map = new int[rows, columns];
        int count = 0;
        for(int i = 0; i < rows; i++){
            for(int j = 0; j < columns; j++){
                map[i, j] = ++count;
            }
        }
        
        for(int i = 0; i < queries.GetLength(0); i++){
            answer[i] = Run(queries[i, 0] - 1, queries[i, 1] - 1, queries[i, 2] - 1, queries[i, 3] - 1, map);
        }
        return answer;
    }
    
    public int Run(int x1, int y1, int x2, int y2, int[,] map){
        int result = 100000;
        int origin = map[x2, y1];
        
        for(int i = y1; i < y2; i++){
            map[x2, i] = map[x2, i + 1];
            if(result > map[x2, i]) result = map[x2, i];
        }
        for(int i = x2; i > x1; i--){
            map[i, y2] = map[i - 1, y2];
            if(result > map[i, y2]) result = map[i, y2];
        }
        for(int i = y2; i > y1; i--){
            map[x1, i] = map[x1, i - 1];
            if(result > map[x1, i]) result = map[x1, i];
        }
        for(int i = x1; i < x2; i++){
            map[i, y1] = map[i + 1, y1];
            if(i == x2 - 1) map[i, y1] = origin;
            if(result > map[i, y1]) result = map[i, y1];
        }
        
        return result;
    }
}