using System;
using System.Linq;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] prices) {
        int[] answer = new int[prices.Length];
        Queue<int> q = new Queue<int>();
        for(int i = 0; i < prices.Length; i++){
            int length = q.Count();
            for(int j = 0; j < length; j++){
                int dq = q.Dequeue();
                answer[dq]++;
                if(prices[dq] > prices[i]) continue;
                q.Enqueue(dq);
            }
            answer[i] = 0;
            q.Enqueue(i);
        }
        return answer;
    }
}
