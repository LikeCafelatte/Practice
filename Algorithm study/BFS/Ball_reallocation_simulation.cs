using System;
using System.Collections.Generic;

public class Solution {
    public long solution(int n, int m, int x, int y, int[,] queries) {
        long answer = 0;
        Queue<int[]> q = new Queue<int[]>();
        q.Enqueue(new int[] {x, y, queries.GetLength(0)});
        while(q.Count > 0){
            var dq = q.Dequeue();
            int current_x = dq[0];
            int current_y = dq[1];
            int current_i = dq[2];
            if(current_x < 0 || current_x >= n || current_y < 0 || current_y >= m) continue;
            if(current_i == 0) {
                answer++;
                continue;
            }
            switch(queries[current_i - 1, 0]){
                case 0:
                    if(current_y == 0){
                        for(int i = 0; i <= queries[current_i - 1, 1]; i++){
                            if(i < m && !q.Contains(new int[] {current_x, current_y + i, current_i - 1}))
                                q.Enqueue(new int[] {current_x, current_y + i, current_i - 1});
                        }
                    }else if(current_y + queries[current_i - 1, 1] < m)
                        q.Enqueue(new int[] {current_x, current_y + queries[current_i - 1, 1], current_i - 1});
                    break;
                case 1:
                    if(current_y == m - 1){
                        for(int i = 0; i <= queries[current_i - 1, 1]; i++){
                            if(i < m && !q.Contains(new int[] {current_x, current_y - i, current_i - 1}))
                                q.Enqueue(new int[] {current_x, current_y - i, current_i - 1});
                        }
                    }else if(current_y - queries[current_i - 1, 1] >= 0)
                        q.Enqueue(new int[] {current_x, current_y - queries[current_i - 1, 1], current_i - 1});
                    break;
                case 2:
                    if(current_x == 0){
                        for(int i = 0; i <= queries[current_i - 1, 1]; i++){
                            if(i < n && !q.Contains(new int[] {current_x + i, current_y, current_i - 1}))
                                q.Enqueue(new int[] {current_x + i, current_y, current_i - 1});
                        }
                    }else if(current_x + queries[current_i - 1, 1] < n)
                        q.Enqueue(new int[] {current_x + queries[current_i - 1, 1], current_y, current_i - 1});
                    break;
                case 3:
                    if(current_x == n - 1){
                        for(int i = 0; i <= queries[current_i - 1, 1]; i++){
                            if(i < n && !q.Contains(new int[] {current_x - i, current_y, current_i - 1}))
                                q.Enqueue(new int[] {current_x - i, current_y, current_i - 1});
                        }
                    }else if(current_x - queries[current_i - 1, 1] >= 0)
                        q.Enqueue(new int[] {current_x - queries[current_i - 1, 1], current_y, current_i - 1});
                    break;
            }
        }
        return answer;
    }
}