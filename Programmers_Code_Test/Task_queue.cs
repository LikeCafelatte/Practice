using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] solution(string[] operations) {
        int[] answer = new int[] {};
        List<int> list = new List<int>();
        foreach(string operation in operations){
            if(operation.Split(' ')[0] == "I")
                list.Add(Int32.Parse(operation.Split(' ')[1]));
            else if(list.Count() == 0)
                continue;
            else if(operation.Split(' ')[1] == "1")
                list.Remove(list.Max());
            else
                list.Remove(list.Min());

        }
        if(list.Count() == 0)
            return new int[] {0, 0};
        return new int[] {list.Max(), list.Min()};
    }
}