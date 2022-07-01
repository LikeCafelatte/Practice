using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(int[] priorities, int location) {
        int answer = 0;
        Queue<int> q_priorities = new Queue<int>(priorities);
        Queue<int> q_locations = new Queue<int> (new int[priorities.Length].Select((num, i) => i));

        int count = 0;
        while(q_priorities.Count() > 0){
            int dq_priority = q_priorities.Dequeue();
            int dq_location = q_locations.Dequeue();
            if(q_priorities.Count() > 0 && q_priorities.Max() > dq_priority) {
                q_priorities.Enqueue(dq_priority);
                q_locations.Enqueue(dq_location);
                continue;
            }

            count++;
            if(dq_location == location) break;
        }
        return count;
    }
}