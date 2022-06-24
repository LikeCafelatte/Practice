using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] progresses, int[] speeds) {
        int[] answer = new int[] {};
        int ckpt= 0;
        int ckpt_backup = 0;
        List<int> ckptList = new List<int>();
        
        while(ckpt < progresses.Length){

        for(int i = ckpt; i < progresses.Length; i++){
            progresses[i] += speeds[i];
            if(progresses[i] >= 100 && i-ckpt==0) ckpt++;
        }
            if(ckpt!=ckpt_backup){
                ckpt_backup=ckpt;
                ckptList.Add(ckpt);
            }
        }
        answer = ckptList.ToArray();
        for(int i = answer.Length - 1; i>0; i--){
            answer[i] -= answer[i-1];
        }
        return answer;
    }
}