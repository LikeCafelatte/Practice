using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public string solution(string number, int k) {
        string answer = "";
        var number_list = number.ToCharArray().Select(c => int.Parse(c.ToString())).ToList();
        int start = 0;
        int max = number_list.Max();
        while(k > 0){
            for(int i = start; i < number_list.Count - 1; i++){
                if(number_list[0] == max && number_list[i] == max && i - start == 1) start = i;
                if(number_list[i] < number_list[i + 1]){
                    number_list.RemoveAt(i);
                    k--;
                    break;
                }
                if(i == number_list.Count - 2){
                    for(int j = 0; j < k; j++){
                        number_list.RemoveAt(i + 1 - j);
                    }
                    k = 0;
                }
            }
            if(k == 0) break;
        }
        answer = string.Join("", number_list);
        return answer;
    }
}