using System;
using System.Collections.Generic;

public class Solution {
    int count = 0;
    public int solution(int n, int[,] computers) {
        //변수 초기화
        bool[] isChecked = new bool[n];
        Queue<KeyValuePair<int, int[]>> computers_q = new Queue<KeyValuePair<int, int[]>>();
        List<int[]> computers_list = new List<int[]>();
        for(int i = 0; i < n; i++){
            int[] temp = new int[n];
            for(int j = 0; j < n; j++){
                temp[j] = computers[i, j];
            }
            computers_list.Add(temp);
        }

        //시작 노드 추가
        computers_q.Enqueue(new KeyValuePair<int, int[]> (0, computers_list[0]));
        count++;

        //BFS 탐색
        while(!AllDoneCheck(computers_q, computers_list, isChecked)){
            //큐에서 꺼낸 후 방문 이력이 있는지 확인 및 방문처리 진행
            KeyValuePair<int, int[]> dq = computers_q.Dequeue();
            if(isChecked[dq.Key]) continue;
            isChecked[dq.Key] = true;

            //노드와 연결된 다른 노드들 확인 후 해당 노드에 방문이력이 없다면 큐에 추가
            for(int i = 0; i < n; i++){
                if(isChecked[i]) continue;
                if(dq.Value[i] == 1) computers_q.Enqueue(new KeyValuePair<int, int[]>(i, computers_list[i]));
            }
        }
        return count;
    }

    // 1. 큐에 남은 것이 있는지 확인, 2. 없으면 모든 노드에 방문했는지 확인, 3. 방문안한 노드가 있다면 추가 후 네트워크 개수 추가
    public bool AllDoneCheck(Queue<KeyValuePair<int, int[]>> q, List<int[]> list, bool[] isChecked){
        if(q.Count > 0) return false;
        for(int i = 0; i < isChecked.Length; i++){
            if(!isChecked[i]){
                q.Enqueue(new KeyValuePair<int, int[]> (i, list[i]));
                count++;
                return false;
            }
        }
        return true;
    }
}