using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(int n, int[,] edge) {
        int answer = 0;
        List<int> currentList = new List<int>();
        int[] distances = new int[n];
        bool[] check = new bool[n];
        int distance = 0;
        currentList.Add(0);
        check[0] = true;
        while(!AllDoneCheck(check)){
            distance++;
            List<int> tempList = new List<int>();
            List<int> addList = new List<int>();
            Queue<int> q = new Queue<int>();
            q.Enqueue(temp);
            foreach(int current in currentList){
                for(int i = 0; i < edge.GetLength(0); i++){
                    if(edge[i, 0] - 1 == current && !check[edge[i, 1] - 1]){
                        check[edge[i, 1] - 1] = true;
                        distances[edge[i, 1] - 1] = distance;
                        addList.Add(edge[i, 1] - 1);
                    }else if(edge[i, 1] - 1 == current && !check[edge[i, 0] - 1]){
                        check[edge[i, 0] - 1] = true;
                        distances[edge[i, 0] - 1] = distance;
                        addList.Add(edge[i, 0] - 1);
                    }
                }
                tempList.Add(current);
            }
            foreach(int temp in tempList){
                currentList.Remove(temp);
            }
            foreach(int add in addList){
                currentList.Add(add);
            }

        }

        return distances.Select(d => d == distances.Max() ? 1 : 0).Sum();
    }
    public bool AllDoneCheck(bool[] check){
        foreach(bool b in check){
            if(!b)
                return false;
        }
        return true;
    }
}