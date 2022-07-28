using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    int[] distances;
    List<int[,]> backup = new List<int[,]>();
    public int solution(int n, int start, int end, int[,] roads, int[] traps) {
        int answer = 0;
        distances = new int[n + 1];
        for(int i = 0; i <= n; i++){
            distances[i] = -1;
        }
        DFS(start, end, roads, traps, 0);
        return distances[end];
    }
    public void DFS(int start, int end, int[,] roads, int[] traps, int time){
        int[,] new_roads = (int[,]) roads.Clone();
        if(distances[start] == -1 || distances[start] > time) distances[start] = time;
        else{
            if(backup.Count > 0){
                bool backupCheck = false;
                foreach(int[,] backuped in backup){
                    for(int i = 0; i< new_roads.GetLength(0); i++){
                        for(int j = 0; j < 3; j++){
                            if(new_roads[i, j] != backuped[i, j]){
                                backup.Add(roads);
                                Console.WriteLine("backup");
                                backupCheck = true;
                                break;
                            }
                        }
                        if(backupCheck) break;
                    }
                    if(backupCheck) break;
                }
                for(int i = 0; i < new_roads.GetLength(0); i++){
                    if(new_roads[i, 0] == start && (distances[new_roads[i,1]] == -1)){
                            backupCheck = true;
                        Console.WriteLine("!!");
                        //return;
                            break;
                    }
                }
                if(!backupCheck) return;
            }else {Console.WriteLine("backup");backup.Add(new_roads);}
        }
        if(start == end) return;
        if(traps.Contains(start)){
            Console.WriteLine("trap");
            for(int i = 0; i < new_roads.GetLength(0); i++){
                if(new_roads[i, 0] == start || new_roads[i, 1] == start){
                    int temp = new_roads[i, 0];
                    new_roads[i, 0] = new_roads[i, 1];
                    new_roads[i, 1] = temp;
                    if(new_roads[i, 0] == start){
                        Console.WriteLine(start + "->" + new_roads[i, 1] + ", " + time);
                        DFS(new_roads[i, 1], end, new_roads, traps, time + new_roads[i, 2]);
                    }
                }
            }
        }else{
            for(int i = 0; i < new_roads.GetLength(0); i++){
                if(new_roads[i, 0] == start){
                    Console.WriteLine(start + "->" + new_roads[i, 1] + ", " + time);
                    DFS(new_roads[i, 1], end, new_roads, traps, time + new_roads[i, 2]);
                }
            }
            
        }
    }
}