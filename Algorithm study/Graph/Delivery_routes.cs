using System;

class Solution
{
    public int solution(int N, int[,] road, int K)
    {
        int answer = 0;
        int[] lengths = new int[N + 1];
        legnths[0] = 500001;
                
        Queue<int[]> q_total = new Queue<int[]>();
        Queue<int[]> q = new Queue<int[]>();
        for(int i = 0; i < road.GetLength(0); i++){
            q_total.Enqueue(new int[] {road[i,0], road[i,1], road[i,2]});
            if(road[i,0] == 1 || road[i,1] == 1){
                q.Enqueue(new int[] {road[i,0], road[i,1], road[i,2], 1});
            }
        }
        int node = 1;
        int new_node = 0;
        while(q.Count > 0){
            var dq = q.Dequeue();
            node = dq[3];
            if(dq[0] == node) new_node = dq[1];
            else new_node = dq[0];
            if(lengths[(node + 1) % 2] == 0 || lengths[node] + dq[2] < lengths[(node + 1) % 2]){
                lengths[(node + 1) % 2] = lengths[node] + dq[2];
            }
            int length = q_total.Count;
            if(length == 0) break;
            for(int i = 0; i < length; i++){
                var dq_total = q_total.Dequeue();
                if(dq_total[0] == node || dq_total[1] == node){
                    continue;
                }
                q.Enqueue(new int[]{dq[0], dq[1], dq[2], });
                
            }
            
        }
        // [실행] 버튼을 누르면 출력 값을 볼 수 있습니다.
        System.Console.WriteLine("Hello C#");

        return answer;
    }
}