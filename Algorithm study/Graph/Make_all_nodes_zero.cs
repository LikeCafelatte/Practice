using System;
using System.Linq;
using System.Collections.Generic;

public class Solution {
    public long solution(int[] a, int[,] edges) {
        if(a.Sum() != 0) return -1;
        long[] a_long = a.Select(i => (long)i).ToArray();
        long answer = 0;
        int[] linked = new int[a.Length];
        bool[] completed = new bool[a.Length];
        bool[] deactivated = new bool[edges.GetLength(0)];
        
        for(int i = 0; i < edges.GetLength(0); i++){
            linked[edges[i,0]]++;
            linked[edges[i,1]]++;
        }
        while(deactivated.Contains(false)){
            for(int i = 0; i < deactivated.Length; i++){
                if(deactivated[i]) continue;
                if(linked[edges[i, 0]] == 1){
                    linked[edges[i, 0]] = 0;
                    linked[edges[i, 1]]--;
                    
                    answer += (a_long[edges[i, 0]] > 0 ? a_long[edges[i, 0]] : -a_long[edges[i, 0]]);
                    a_long[edges[i, 1]] += a_long[edges[i, 0]];
                    a_long[edges[i, 0]] = 0; deactivated[i] = true;
                }else if(linked[edges[i, 1]] == 1){
                    linked[edges[i, 0]]--;
                    linked[edges[i, 1]] = 0;
                    
                    answer += (a_long[edges[i, 1]] > 0 ? a_long[edges[i, 1]] : -a_long[edges[i, 1]]);
                    a_long[edges[i, 0]] += a_long[edges[i, 1]];
                    a_long[edges[i, 1]] = 0; deactivated[i] = true;
                }
            }
        }
        return answer;
    }
}
