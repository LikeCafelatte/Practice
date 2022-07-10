using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(int[,] land, int height) {
        //변수 초기화
        int[,] group_map =  new int[land.GetLength(0), land.GetLength(1)];
        bool[,] isExplored = new bool[land.GetLength(0), land.GetLength(1)];
        Land.land = land;
        Land.threshold = height;
        Queue<Land> q = new Queue<Land>();
        List<Land> land_list = new List<Land>();
        
        // 0, 0부터 탐색 시작
        q.Enqueue(new Land(0, 0, 0));
        // BFS 알고리즘으로 탐색
        // height 이하의 차이로 이어진 땅들을 한 묶음(한개의 리스트)으로 인식
        // q에 대기열이 없고 아직 탐색이 완료되지 않은 땅이 있으면 새로운 땅 묶음(새로운 리스트) 탐색
        int count = 0;
        while(q.Count > 0){
            Land dq = q.Dequeue();
            if(isExplored[dq.x, dq.y]) continue;
            land_list.Add(dq);
            isExplored[dq.x, dq.y] = true;
            group_map[dq.x, dq.y] = dq.group_id;
            if(dq.gap[0] <= height && !isExplored[dq.x - 1, dq.y]) q.Enqueue(new Land(dq.x - 1, dq.y, count));
            if(dq.gap[1] <= height && !isExplored[dq.x + 1, dq.y]) q.Enqueue(new Land(dq.x + 1, dq.y, count));
            if(dq.gap[2] <= height && !isExplored[dq.x, dq.y - 1]) q.Enqueue(new Land(dq.x, dq.y - 1, count));
            if(dq.gap[3] <= height && !isExplored[dq.x, dq.y + 1]) q.Enqueue(new Land(dq.x, dq.y + 1, count));
            if(q.Count == 0){
                int[] next_Target = GetNextTarget(isExplored);
                if(next_Target[0] != -1){
                    count++;
                    q.Enqueue(new Land(next_Target[0], next_Target[1], count));
                }
            }
        }
        //Kruskal algorithm
        //다른 그룹의 땅들과 인접한 곳에서 엣지 정보 추출
        Queue<KeyValuePair<int[], int>> temp_q_node = new Queue<KeyValuePair<int[], int>>();
        foreach(Land l in land_list){
            if(!l.isBordered) continue;
            if(l.isBorderline[0] && l.group_id != group_map[l.x - 1, l.y]) 
                temp_q_node.Enqueue(new KeyValuePair<int[], int> ((l.group_id < group_map[l.x - 1, l.y] ? 
                    new int[2] {l.group_id, group_map[l.x - 1, l.y]} : new int[2] {group_map[l.x - 1, l.y], l.group_id}), l.gap[0]));
            if(l.isBorderline[1] && l.group_id != group_map[l.x + 1, l.y]) 
                temp_q_node.Enqueue(new KeyValuePair<int[], int> ((l.group_id < group_map[l.x + 1, l.y] ? 
                    new int[2] {l.group_id, group_map[l.x + 1, l.y]} : new int[2] {group_map[l.x + 1, l.y], l.group_id}), l.gap[1]));
            if(l.isBorderline[2] && l.group_id != group_map[l.x, l.y - 1]) 
                temp_q_node.Enqueue(new KeyValuePair<int[], int> ((l.group_id < group_map[l.x, l.y - 1] ? 
                    new int[2] {l.group_id, group_map[l.x, l.y - 1]} : new int[2] {group_map[l.x, l.y - 1], l.group_id}), l.gap[2]));
            if(l.isBorderline[3] && l.group_id != group_map[l.x, l.y + 1]) 
                temp_q_node.Enqueue(new KeyValuePair<int[], int> ((l.group_id < group_map[l.x, l.y + 1] ? 
                    new int[2] {l.group_id, group_map[l.x, l.y + 1]} : new int[2] {group_map[l.x, l.y + 1], l.group_id}), l.gap[3]));
        }
        
        //비용 기준 오름차순 정렬
        List<KeyValuePair<int[], int>> node_list = temp_q_node.OrderBy(kv => kv.Value).ToList();
        
        //kruskal algorithm 수행
        int[] parent = new int[count + 1];
        for(int i = 0; i < parent.Length; i++){
            parent[i] = i;
        }
        UnionFind uf = new UnionFind();

        int sum = 0;
        for(int i = 0; i < node_list.Count; i++){
            if(!uf.FindParent(parent, node_list[i].Key[0], node_list[i].Key[1])){
                sum += node_list[i].Value;
                uf.UnionParent(parent, node_list[i].Key[0], node_list[i].Key[1]);
            }
        }

        return sum;
    }
    
    int[] GetNextTarget(bool[,] isExplored){
        for(int i = 0; i < isExplored.GetLength(0); i++){
            for(int j = 0; j < isExplored.GetLength(1); j++){
                if(!isExplored[i, j]) return new int[2]{i, j};
            }
        }
        return new int[2] {-1, -1};
    }

    public class Land{
        public int x;
        public int y;
        public int height;
        public int group_id;
        public int[] gap;
        public bool isBordered;
        public bool[] isBorderline = new bool[4];
        public static int[,] land;
        public static int threshold;

        public Land(int x, int y, int group_id){
            this.x = x;
            this.y = y;
            this.height = land[x, y];
            this.group_id = group_id;
            gap = new int[4] {10001, 10001, 10001, 10001};
            if(this.x > 0) gap[0] = (land[x - 1, y] - height > 0 ? land[x - 1, y] - height : height - land[x - 1, y]);
            if(this.x < land.GetLength(0) - 1) gap[1] = (land[x + 1, y] - height > 0 ? land[x + 1, y] - height : height - land[x + 1, y]);
            if(this.y > 0) gap[2] = (land[x, y - 1] - height > 0 ? land[x, y - 1] - height : height - land[x, y - 1]);
            if(this.y < land.GetLength(1) - 1) gap[3] = (land[x, y + 1] - height > 0 ? land[x, y + 1] - height : height - land[x, y + 1]);
            
            for(int i = 0; i < 4; i++){
                if(gap[i] != 10001 && gap[i] > threshold){
                    isBordered = true;
                    isBorderline[i] = true;
                }
            }
        }
    }

    public class UnionFind{

        public int GetParent(int[] parent, int x){
            if(parent[x] == x) return x;
            return parent[x] = GetParent(parent, parent[x]);
        }

        public void UnionParent(int[] parent, int a, int b){
            a = GetParent(parent, a);
            b = GetParent(parent, b);
            if(a < b) parent[b] = a;
            else parent[a] = b;
        }

        public bool FindParent(int[] parent, int a, int b){
            a = GetParent(parent, a);
            b = GetParent(parent, b);
            if(a == b) return true;
            else return false;
        }
    }
}