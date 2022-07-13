using System;

public class Solution {
    public int solution(int bridge_length, int weight, int[] truck_weights) {
        int t = 1;
        int i = 0;
        int count = 0;
        int[] truck_out_times = new int[truck_weights.Length];
        int weighted = 0;
        weighted += truck_weights[i];
        count++;
        truck_out_times[i] = t + bridge_length;
        i++;
        while(i < truck_weights.Length){
            t++;
            if(truck_out_times[i - count] == t) weighted -= truck_weights[i - count--];
            if(weight - weighted < truck_weights[i]) {
                t = truck_out_times[i - count] - 1;
                continue;
            }
            weighted += truck_weights[i];
            count++;
            truck_out_times[i] = t + bridge_length;
            i++;
        }
        return truck_out_times[i - 1];
    }
}