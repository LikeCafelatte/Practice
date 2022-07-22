using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    public int solution(int N, int[,] road, int K)
    {
        int answer = 0;
        Town[] towns = new Town[N + 1];
        for(int i = 0; i < N + 1; i++){
            towns[i] = new Town(i);
        }
                
        Queue<int[]> q_total = new Queue<int[]>();
        Queue<Town> q = new Queue<Town>();
        for(int i = 0; i < road.GetLength(0); i++){
            q_total.Enqueue(new int[] {road[i,0], road[i,1], road[i,2]});
        }
        q.Enqueue(towns[1]);
        
        int node = 1;
        while(q.Count > 0){
            q = new Queue<Town>(q.OrderBy(t => t.distance));
            var dq = q.Dequeue();
            node = dq.id;
            
            int length = q_total.Count;
            if(length == 0) continue;
            for(int i = 0; i < length; i++){
                var dq_total = q_total.Dequeue();
                if(dq_total[0] == node || dq_total[1] == node){
                    if(dq_total[0] == node && (towns[dq_total[1]].distance == 0 || 
                        towns[node].distance + dq_total[2] < towns[dq_total[1]].distance)){
                        towns[dq_total[1]].distance = towns[node].distance + dq_total[2];
                        q.Enqueue(towns[dq_total[1]]);
                    }
                    else if(dq_total[1] == node && (towns[dq_total[0]].distance == 0 || 
                        towns[node].distance + dq_total[2] < towns[dq_total[0]].distance)){
                        towns[dq_total[0]].distance = towns[node].distance + dq_total[2];
                        q.Enqueue(towns[dq_total[0]]);
                    }
                    continue;
                }
                q_total.Enqueue(dq_total);
            }
            
        }
        
        return towns.Where(t => t.distance <= K).Count();
    }
    
    public class Town{
        public int id;
        public int distance;
        
        public Town(int id){
            this.id = id;
            if(id == 0) distance = 500001;
            else distance = 0;
        }
    }
}