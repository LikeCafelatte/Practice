using System;
using System.Linq;
using System.Collections.Generic;

public class Solution {
    public int[] solution(string[] genres, int[] plays) {
        List<int> answer = new List<int>();
        var dic = Enumerable.Range(0, genres.Length).GroupBy(i => genres[i], i => new int[] {plays[i], i}).OrderByDescending(g => g.Sum(arr => arr[0])).ToDictionary(g => g.Key);
        foreach(var d in dic){
            var list = d.Value.OrderByDescending(arr => arr[0]).ToList();
            for(int i = 0; i < d.Value.Count(); i++){
                answer.Add(list[i][1]);
                if(i == 1) break;
            }
        }
        return answer.ToArray();
    }
}