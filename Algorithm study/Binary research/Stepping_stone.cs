using System;
using System.Linq;
using System.Collections.Generic;

public class Solution {
    public int solution(int distance, int[] rocks, int n) {
        //변수 초기화 및 오름차순 정렬
        int answer = 0;
        int lastRock = 1;
        rocks = rocks.OrderBy(i => i).ToArray();
        List<int> distances = new List<int>();
        
        //각 바위사이 거리 초기값
        for(int i = 0; i < rocks.Length; i++){
            distances.Add(rocks[i] - lastRock);
            lastRock = rocks[i];
        }
        distances.Add(distance - lastRock);
        
        //바위사이 거리가 가장 작은 값 제거 및 앞 or 뒤에 합산
        //앞 or 뒤 합산 기준은 더 작은 값으로 합산
        for(int i = 0; i < n; i++){
            int min = distances.Min();
            int idx = distances.IndexOf(min);
            if(idx > 0 && idx < distances.Count() - 1){
                if(distances[idx - 1] < distances[idx + 1]){
                    distances[idx - 1] += min + 1;
                }
                else{
                    distances[idx + 1] += min + 1;
                }
            }
            else if(idx == 0){
                distances[idx + 1] += min + 1;
            }
            else{
                distances[idx - 1] += min + 1;
            }
            distances.Remove(min);
        }
        return distances.Min();
    }
}