using System;
using System.Linq;
using System.Collections.Generic;

public class Solution {
    public long solution(int[] a, int[,] edges) {
        if(a.Sum() != 0) return -1;
        List<List<long>> nodes = a.Select(n => new List<long>(new long[]{n, 0})).ToList();
        
        for(int i = 0; i < edges.GetLength(0); i++){
            nodes[edges[i,0]].Add(edges[i,1]);
            nodes[edges[i,1]].Add(edges[i,0]);
        }

        return DFS(nodes, 0, -1)[1];
    }

    public long[] DFS(List<List<long>> nodes, int node, int source){
        long[] result = new long[] {nodes[node][0], nodes[node][1]};
        for(int i = 2; i < nodes[node].Count(); i++){
            if((int) nodes[node][i] == source) continue;
            long[] temp = DFS(nodes, (int) nodes[node][i], node);
            result[0] += temp[0];
            result[1] += temp[1] + Math.Abs(temp[0]);
        }
        return result;
    }
}