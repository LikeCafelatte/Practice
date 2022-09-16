// 징검다리
// https://school.programmers.co.kr/learn/courses/30/lessons/43236

using System;
using System.Linq;
using System.Collections.Generic;

public class Solution {
    public int solution(int distance, int[] rocks, int n) {
        //바위 개수와 제거할 개수가 동일하면 전체 거리를 출력
        if(rocks.Length == n) return distance;
        //변수 초기화 및 오름차순 정렬
        rocks = rocks.OrderBy(i => i).ToArray();
        
        
        return BinarySearch(distance, new List<int>(rocks), n);
    }
    
    // binary search algorithm
    // 기준 바위와 떨어진 거리가 mid 보다 작으면 제거
    // mid 보다 크면 새 기준 바위로 지정
    // 제거한 바위의 총 개수가 n 보다 크면 high = mid
    // 작으면 low = mid + 1
    // binary search의 결과로 제거된 바위수가 항상 n과 동일할 수 없음. n과 같거나 작은 상태를 유지하는 가장 큰수가 result
    // count == n일때, result - 1보다 작거나 같은 모든 경우가 지워지고 가장 가까운 거리는 result와 동일
    // count < n 일때, result 만큼 떨어진 바위들이 여러 쌍 있으나, n 개를 다 지워도 1개 이상의 바위 쌍이 남음
    public int BinarySearch(int distance, List<int> rocks, int n){
        int high = distance;
        int low = 1;
        int mid = (high + low) / 2;
        int result = 0;
        while(high > low){
            int count = 0;
            int last_rock = 0;
            mid = (high + low) / 2;
            var new_rocks = new List<int>(rocks);
            new_rocks.Add(distance);
            for(int i = 0; i < new_rocks.Count(); i++){
                if(new_rocks[i] - last_rock < mid){
                    count++;
                }else{
                    last_rock = new_rocks[i];
                }
            }
            if(count > n){
                high = mid;
            }else{
                low = mid + 1;
                result = mid;
            }
        }
        return result;
    }
}
