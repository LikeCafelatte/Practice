using System;
using System.Linq;

public class Solution {
    public int solution(int n, int[,] costs) {
        int answer = 0;
        var new_costs = Enumerable.Range(0, costs.GetLength(0)).Select(i => new int[]{costs[i, 0], costs[i, 1], costs[i, 2]}).OrderBy(arr => arr[2]).ToArray();
        for(int i = 0; i < new_costs.Length; i++){
            costs[i, 0] = new_costs[i][0];
            costs[i, 1] = new_costs[i][1];
            costs[i, 2] = new_costs[i][2];
        }
        int[] parent = new int[n + 1];
        for(int i = 0; i < parent.Length; i++){
            parent[i] = i;
        }
        UnionFind uf = new UnionFind();

        for(int i = 0; i < costs.GetLength(0); i++){
            if(!uf.FindParent(parent, costs[i, 0], costs[i, 1])){
                Console.WriteLine(costs[i, 0] + ", " + costs[i, 1] + ", " + costs[i, 2]);
                answer += costs[i, 2];
                uf.UnionParent(parent, costs[i, 0], costs[i, 1]);
            }
        }
        
        return answer;
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