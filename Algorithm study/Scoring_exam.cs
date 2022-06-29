using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] solution(int[] answers) {
        int[] answer = new int[] {};
        int[] pattern_1st = new int[] {1, 2, 3, 4, 5};
        int[] pattern_2nd = new int[] {2, 1, 2, 3, 2, 4, 2, 5};
        int[] pattern_3rd = new int[] {3, 3, 1, 1, 2, 2, 4, 4, 5, 5};
        int[] score = new int[3];
        int length_1st = pattern_1st.Length;
        int length_2nd = pattern_2nd.Length;
        int length_3rd = pattern_3rd.Length;
        for(int i = 0; i < answers.Length; i++){
            if(answers[i] == pattern_1st[i % length_1st])
                score[0]++;
            if(answers[i] == pattern_2nd[i % length_2nd])
                score[1]++;
            if(answers[i] == pattern_3rd[i % length_3rd])
                score[2]++;
        }
        var score_list = new List<int>(score);
        int high_score = score_list.Max();
        answer = score_list.Select((j, i)=> j == high_score ? i + 1 : 0).Where(i => i > 0).ToArray();


        return answer;
    }
}