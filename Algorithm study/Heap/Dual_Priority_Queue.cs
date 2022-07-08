using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    List<int> q_list = new List<int>();
    public int[] solution(string[] operations) {
        for(int i = 0; i < operations.Length; i++){
            switch(operations[i].Split(' ')[0]){
                case "I":
                    I(Int32.Parse(operations[i].Split(' ')[1]));
                    break;
                case "D":
                    D(Int32.Parse(operations[i].Split(' ')[1]));
                    break;
            }
        }
        if(q_list.Count == 0) return new int[2] {0, 0};
        return new int[2] {q_list.Max(), q_list.Min()};
    }
    public void I(int i){
        q_list.Add(i);
    }
    public void D(int i){
        if(q_list.Count == 0) return;
        if(i == 1){
            q_list = q_list.OrderByDescending(num => num).ToList();
            q_list.RemoveAt(0);
        }else if(i == -1){
            q_list = q_list.OrderBy(num => num).ToList();
            q_list.RemoveAt(0);
        }
    }
}