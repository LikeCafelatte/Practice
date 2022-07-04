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


using System;
using System.Linq;
using System.Collections.Generic;

public class Solution {
    public int solution(int distance, int[] rocks, int n) {
        //변수 초기화 및 오름차순 정렬
        int lastRock = 1;
        rocks = rocks.OrderBy(i => i).ToArray();
        List<int> distances = new List<int>();
        
        //각 바위사이 거리 초기값
        for(int i = 0; i < rocks.Length; i++){
            distances.Add(rocks[i] - lastRock);
            lastRock = rocks[i];
        }
        distances.Add(distance - lastRock);
        
        // binary search algorithm
        // distances의 최소값과 최대값 사이를 탐색
        // 최소 최대의 중간값 부터 탐색해서 mid값을 threshold로 만족하기 위해 제거되는 총 바위 개수가 n보다 크면 mid 이상값은 탐색할 필요 없으므로 high를 mid - 1로 수정
        // n보다 작을때도 마찬가지 방식으로 탐색범위를 반씩 좁혀나감
        int high = distances.Max() * n;
        int low = distances.Min();
        int mid = (high + low) / 2;
        
        int count = 0;
        int temp_mid = 0;
        while(high > low){
            mid = (high + low) / 2;
            count++;
            //Console.WriteLine(low + ", " + mid + ", " + high);
            if(GetNumberOfNecessaryRocks(distances, mid) > n){
                high = mid - 1;
            }
            else if(GetNumberOfNecessaryRocks(distances, mid) == n){
                return mid;
            }
            else{
                low = mid;
            }
            if(temp_mid == mid) break;
            temp_mid = mid;
        }
        Console.WriteLine(GetNumberOfNecessaryRocks(distances, 4));
        return high;
    }
    
    // i번째 거리가 threshold 값보다 작거나 같으면, count++ 후 new_list[i]값을 앞뒤 크기 비교후 작은쪽에 더함
    // 간격이 1, 2, 3 .....이고 threshold가 8이라고 가정하면 첫번째, 두번재 바위를 다 제거해야하는 케이스가 있음
    public int GetNumberOfNecessaryRocks(List<int> distances, int threshold){
        int count = 0;
        List<int> new_list = new List<int> (distances);
        for(int i = 0; i < new_list.Count(); i++){
            if(new_list[i] < threshold) {
                count++;
                if(i > 0 && i < distances.Count() - 1){
                    if(new_list[i - 1] < new_list[i + 1]){
                        new_list[i - 1] += new_list[i] + 1;
                    }
                    else{
                        new_list[i + 1] += new_list[i] + 1;
                    }
                }
                else if(i == 0){
                    new_list[i + 1] += new_list[i] + 1;
                }else{
                    new_list[i - 1] += new_list[i] + 1;
                }
                new_list.RemoveAt(i);
            }
        }
        return count;
    }
}