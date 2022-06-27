using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public string solution(int[] numbers) {
        string answer = "";
        var numbersList = numbers.OrderByDescending(n => n).Select(n => GetSingleDigit(n)).OrderBy(list => list.Count()).OrderByDescending(list => list[0]).ToList();
        Dictionary<int, List<List<int>>> numbersDictionary = new Dictionary<int, List<List<int>>>();
        for(int i = 0; i < 10; i++){
            numbersDictionary.Add(i, new List<List<int>>());
        }
        foreach(List<int> numList in numbersList){
            numbersDictionary[numList[0]].Add(numList);
        }
        for(int i = 9; i>= 0; i--){
            for(int j = 0; j < numbersDictionary[i].Count() - 1; j++){
                
            }
        }
        for(int i = 9; i>= 0; i--){
            foreach(List<int> numList in numbersDictionary[i]){
                foreach(int num in numList){
                    answer+=num.ToString();
                }
            }
        }
        return answer;
    }
    public List<int> GetSingleDigit(int num){
        Stack<int> stack = new Stack<int>();
        while(num / 10 > 0){
            stack.Push(num%10);
            num /= 10;
        }
        stack.Push(num);
        return stack.ToList();
    }
}