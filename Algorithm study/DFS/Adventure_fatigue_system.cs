using System;
using System.Collections.Generic;

public class Solution {
    int answer = -1;
    public int solution(int k, int[,] dungeons) {
        List<int[]> dungeons_list = new List<int[]>();
        for(int i = 0; i < dungeons.GetLength(0); i++){
            dungeons_list.Add(new int[] {dungeons[i, 0], dungeons[i, 1]});
        }
        Sol(k, dungeons_list, 0);
        return answer;
    }
    
    public void Sol(int rest, List<int[]> list, int depth){
        int length = list.Count;
        bool isAllDone = true;
        for(int i = 0; i < length; i++){
            if(rest < list[i][0]) continue;
            int temp_rest = rest;
            isAllDone = false;
            temp_rest -= list[i][1];
            var temp_list = new List<int[]>(list);
            temp_list.RemoveAt(i);
            Sol(temp_rest, temp_list, depth + 1);
        }
        if(isAllDone && answer < depth) answer = depth;
    }
}