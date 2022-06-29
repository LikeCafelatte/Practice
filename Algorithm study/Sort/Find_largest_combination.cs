using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public string solution(int[] numbers) {
        string answer = "";
        var numbersList = numbers.OrderByDescending(n => n, new ComparerClass());
        foreach(int num in numbersList){
            answer+=num.ToString();
        }
        if(numbersList.Max() == 0) return "0";
        return answer;
    }
    
    public class ComparerClass : IComparer<int>
    {
        public int Compare(int x, int y){
            long origin = long.Parse(x.ToString() + y.ToString());
            long reverse = long.Parse(y.ToString() + x.ToString());
            
            if(origin > reverse) return 1;
            if(origin < reverse) return -1;
            if(origin == reverse) return 0;
            return 0;
        }
    }
}