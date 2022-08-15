using System;
using System.Collections.Generic;

public class Solution {
    public long solution(int n, int m, int x, int y, int[,] queries) {
        long answer = 0;
        int[] x_axis = new int[] {x, x};
        int[] y_axis = new int[] {y, y};
        for(int i = queries.GetLength(0) - 1; i >= 0 ; i--){
            switch(queries[i, 0]){
                case 0:
                    if(y_axis[0] != 0) y_axis[0] += queries[i, 1];
                    y_axis[1] += queries[i, 1];
                    break;
                case 1:
                    if(y_axis[1] != m - 1) y_axis[1] -= queries[i, 1];
                    y_axis[0] -= queries[i, 1];
                    break;
                case 2:
                    if(x_axis[0] != 0) x_axis[0] += queries[i, 1];
                    x_axis[1] += queries[i, 1];
                    break;
                case 3:
                    if(x_axis[1] != n - 1) x_axis[1] -= queries[i, 1];
                    x_axis[0] -= queries[i, 1];
                    break;
            }
            if(y_axis[0] < 0){
                if(y_axis[1] < 0) return 0;
                y_axis[0] = 0;
            }
            if(y_axis[1] > m - 1){
                if(y_axis[0] > m - 1) return 0;
                y_axis[1] = m - 1;
            }
            if(x_axis[0] < 0){
                if(x_axis[1] < 0) return 0;
                x_axis[0] = 0;
            }
            if(x_axis[1] > n - 1){
                if(x_axis[0] > n - 1) return 0;
                x_axis[1] = n - 1;
            }
        }
        answer = (long)(x_axis[1] - x_axis[0] + 1) * (long)(y_axis[1] - y_axis[0] + 1);
        return answer;
    }
}