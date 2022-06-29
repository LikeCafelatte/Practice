using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(int[] priorities, int location) {
        int answer = 0;
        var list = priorities.Select((val, idx) => new int[] {idx, val}).ToList();
        var priorities_list = priorities.ToList();
        while(list.Count() > 0){
            if(list.First()[1] < priorities_list.Max()){
                int[] temp = list.First();
                list.Remove(temp);
                list.Add(temp);
            }else{
                if(list.First()[0] == location)
                    return answer+1;
                list.Remove(list.First());
                answer++;
                priorities_list.Remove(priorities_list.Max());
            }
            Console.WriteLine(answer + ", " + list.First()[0] + ", " + list.First()[1]);
            
        }
        return answer;
    }
}