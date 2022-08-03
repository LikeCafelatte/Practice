using System;
using System.Linq;

public class Solution {
    public int solution(int[] citations) {
        int answer = 0;
        int high = citations.Length;
        int low = 0;
        int mid = (high + low) / 2;
        while(high > low){
            if(citations.Where(n => n >= mid).Count() >= mid) low = mid;
            else high = mid - 1;
            mid = (high + low) / 2 + (high + low) % 2;
        }
        return low;
    }
}
