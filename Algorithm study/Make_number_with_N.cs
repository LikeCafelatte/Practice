using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    int count = 0;
    List<int>[] cases = new List<int>[9];
    public int solution(int N, int number) {
        int answer = 0;

        return Do(N, number, answer);
    }
    public int Do(int N, int number, int answer){
        answer++;
        if(answer > 8)
            return -1;
        if(answer == 1){
            int num = 0;
            for(int i = 1; i < 9; i++){
                cases[i] = new List<int>();
                num = num*10+N;
                cases[i].Add(num);
            }
        }
        else
        for(int i = 1; i < answer; i++){
            foreach(int n in cases[i]){
                foreach(int m in cases[answer - i]){
                    cases[answer].Add(m + n);
                    if(m != n)
                    cases[answer].Add(m - n);
                    cases[answer].Add(m * n);
                    if(m%n==0)
                    cases[answer].Add(m / n);
                }
            }
        }
        if(cases[answer].Contains(number))
            return answer;
        cases[answer] = cases[answer].Where(i => i < 32000 * N && i != 0).Distinct().ToList();
        for(int i = 1; i < answer; i++){
            cases[answer].Where(n => !cases[i].Contains(n));
        }
        return Do(N, number, answer);
    }
}