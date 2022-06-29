using System;
using System.Text;
using System.Collections.Generic;

public class Solution {
    public string solution(int[] numbers) {
        StringBuilder myStringBuilder = new StringBuilder("");
        Array.Sort(numbers, new ComparerClass());
        foreach(int num in numbers){
            myStringBuilder.Append(num);
        }
        if(numbers[0] == 0) return "0";
        return myStringBuilder.ToString();
    }
    
    public class ComparerClass : IComparer<int>
    {
        public int Compare(int x, int y){
            long origin = long.Parse(x.ToString() + y.ToString());
            long reverse = long.Parse(y.ToString() + x.ToString());
            
            if(origin > reverse) return -1;
            if(origin < reverse) return 1;
            if(origin == reverse) return 0;
            return 0;
        }
    }
}