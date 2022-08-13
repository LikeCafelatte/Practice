using System;
using System.Linq;
using System.Collections.Generic;

public class Solution {
    public string[] solution(string[,] tickets) {
        string[] answer = new string[] {};
        string[][] new_tickets = Enumerable.Range(0, tickets.GetLength(0)).Select(i => new string[] {tickets[i, 0], tickets[i, 1]}).OrderByDescending(arr => arr[1]).ToArray();
        Stack<List<int>> stack = new Stack<List<int>>();
        for(int i = 0; i < new_tickets.Length; i++){
            if(new_tickets[i][0].Equals("ICN")) {
                List<int> temp = new List<int>();
                temp.Add(i);
                stack.Push(temp);
            }
        }
        while(stack.Count() > 0){
            List<int> pop = stack.Pop();
            string current_airport = new_tickets[pop[pop.Count() - 1]][1];
            if(pop.Count() == new_tickets.Length) return pop.Select(i => new_tickets[i][1]).Prepend("ICN").ToArray();
            for(int i = 0; i < new_tickets.Length; i++){
                if(pop.Contains(i)) continue;
                if(new_tickets[i][0].Equals(current_airport)){
                    List<int> temp = new List<int> (pop);
                    temp.Add(i);
                    stack.Push(temp);
                }
            }
        }
        return answer;
    }
}