using System;
using System.Collections.Generic;

class Solution
{
    public int solution(int n, int[] stations, int w){
        int answer =0;
        List<int> list = new List<int>();

        if(stations[0] - w > 1)
            list.Add(stations[0] - w - 1);
        for(int i = 1; i < stations.Length; i++){
            if(stations[i] - w - (stations[i - 1] + w) - 1 > 0)
                list.Add(stations[i] - w - (stations[i - 1] + w) - 1);
        }
        if(stations[stations.Length - 1] + w < n)
            list.Add(n - (stations[stations.Length - 1] + w));

        foreach(int a in list){
            Console.WriteLine(a);
            answer += a / (2 * w + 1) + (a % (2 * w + 1) == 0 ? 0 : 1);
        }

        return answer;
    }
}