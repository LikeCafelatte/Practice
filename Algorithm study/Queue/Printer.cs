using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(int[] priorities, int location) {
        int answer = 0;
        var q_priorities = new Queue<KeyValuePair<int, int>>(priorities.Select((num, i) => new KeyValuePair<int, int>(i, num)));
        Queue<int> q_locations = new Queue<int> (new int[priorities.Length].Select((num, i) => i));
        
        int count = 0;
        while(q_priorities.Count() > 0){
            var key_value = q_priorities.Dequeue();
            if(q_priorities.Count() > 0 && key_value.Value < q_priorities.Max(x => x.Value)){
                q_priorities.Enqueue(key_value);
                continue;
            }
            count++;
            if(key_value.Key == location) break;
        }
        return count;
    }
}