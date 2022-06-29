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
        
        foreach(List<int> numList in numbersDictionary){
            for(int i = 1; i < numList.Count(); i++){
                int k = i;
                while(k > 0 && !isSortingDone(numList, k)){

                }
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

    public bool isSortingDone(List<int> numList, int k){
        if(k == 0)
            return true;
        if(numList[k - 1].Count() > numList[k].Count()){
            for(int i = 1; i < numList[k].Count(); i++){
                if(numList[k - 1][i] > numList[k][i]) return false;
                if(numList[k - 1][i] < numList[k][i]) return true; 
            }
            if(numList[k - 1][numList[k].Count() > ])
        }
    }
}