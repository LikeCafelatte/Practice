using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    List<List<int[]>> list_of_waitingList = new List<List<int[]>>();
    int time = 0;
    public int solution(int[,] jobs) {
        int answer = 0;
        //값 초기화
        List<int[]> jobList = new List<int[]>();
        for(int i = 0; i < jobs.GetLength(0); i++){
            jobList.Add(new int[]{jobs[i,0], jobs[i,1]});
        }
        jobList = jobList.OrderBy(a=>a[0]).ToList();
        List<int[]> waitingList = new List<int[]>();
        List<int> processingTimeList = new List<int>();
        
        //전체 작업 완료까지 반복
        while(jobList.Count() > 0 || waitingList.Count() > 0){
            // 현재시간 이전에 요청받은 작업들 대기열에 추가
            var tempList = jobList.Where(a => a[0] <= time).ToList();
            foreach(var temp in tempList){
                jobList.Remove(temp);
                waitingList.Add(temp);
            }
            // 현재시간기준 대기중인 요청이 없으면 다음 요청이 들어오는 시간으로 변경
            if(waitingList.Count() == 0){
                time = jobList[0][0];
            }
            else{// 대기중인 요청이 있으면 처리
                // 대기열 내의 작업들을 기준으로 처리시간이 짧은 순서로 재배열
                waitingList = waitingList.OrderBy(a => a[1]).ToList();
                
                processingTimeList.Add(time + waitingList[0][1] - waitingList[0][0]);
                time += waitingList[0][1];
                waitingList.Remove(waitingList[0]);
            }
        }
        
        return (int)processingTimeList.Average();
    }
    
}