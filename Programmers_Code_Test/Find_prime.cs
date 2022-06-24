using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    List<int> prime_num = new List<int>();
    public int solution(string numbers) {
        int answer = 0;
        List<string> strList = numbers.ToCharArray().Select(c => c.ToString()).ToList();
        var numStrList = getNumStrList("", strList);
        var resultList = numStrList.Select(s => Int32.Parse(s)).Distinct().ToList();
        
        foreach(int n in resultList){
            if(PrimeCheck(n)){
                answer++;
                Console.WriteLine(n);
            }
        }
        
        return answer;
    }
    
    public List<string> getNumStrList(string numStr, List<string> numStrList){
        List<string> temp = new List<string>();
        foreach(string s in numStrList){
            temp.Add(numStr + s);
            int count=0;
            foreach(string result in getNumStrList(numStr+s, numStrList.Where(i => i != s ? true : count++ != 0).ToList()))
                temp.Add(result);
        }
        return temp;
    }
    
    public bool PrimeCheck(int num){
        if(num <= 1)
            return false;
        if(num == 2 || num == 3)
            return true;
        if(num == 4)
            return false;
        
        for(int i = 2; i*i <= num; i++){
            if(num % i == 0)
                return false;
        }
        return true;
    }

    public void Permutation(List<int> list, int start, int end){
        List<int> temp = new List<int>();
        if(start == end){
            int count = 1;
            list.Select(i => i*(count*=10)).Sum();
        }
        else{
            for(int i = start; i < end; i++){
                int temp = list[start];
                list[start] = list[i];
                list[i] = temp;

                Permutation(list, start + 1, end);

                temp = list[start];
                list[start] = list[i];
                list[i] = temp;
            }
        }
    }
}