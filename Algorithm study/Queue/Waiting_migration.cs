using System;
using System.Linq;

public class Solution {
    public long solution(int n, int[] times) {
        long answer = 0;
        long high = (long) times.Max() * (long)n;
        long low = 0;
        long mid = (high + low)/2;
        
        while(high > low){
            mid = (high + low)/2;

            if(times.Select(t => mid/t).Sum() == n && times.Select(t => (mid - 1)/t).Sum() < n)
                return mid;
            if(times.Select(t => mid/t).Sum() < n)
                low = mid + 1;
            else
                high = mid;
        }
        return low;
    }
}