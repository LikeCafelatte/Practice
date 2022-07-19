using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(int n, int[,] results) {
        int answer = 0;
        Boxer[] boxers = new Boxer[n + 1];
        boxers = boxers.Select((boxer, idx) => new Boxer(idx)).ToArray();
        for(int i = 0; i < results.GetLength(0); i++){
            boxers[results[i, 0]].upperRank.Add(boxers[results[i, 1]]);
            boxers[results[i, 1]].lowerRank.Add(boxers[results[i, 0]]);
        }
        for(int i = 1; i < n + 1; i++){
            if(boxers[i].GetUpperRank(n).Count + boxers[i].GetLowerRank(n).Count == n - 1) answer++;
        }
        return answer;
    }

    public class Boxer{
        public int id;
        public List<Boxer> upperRank = new List<Boxer>();
        public List<Boxer> lowerRank = new List<Boxer>();
        bool upperSearchingDone = false;
        bool lowerSearchingDone = false;

        public Boxer(int id){
            this.id = id;
        }

        public List<Boxer> GetUpperRank(int n){
            for(int i = 0; i < upperRank.Count; i++){
                if(upperSearchingDone || upperRank.Count + lowerRank.Count == n - 1) return upperRank;
                foreach(Boxer new_boxer in upperRank[i].GetUpperRank(n)){
                    if(!upperRank.Contains(new_boxer)) upperRank.Add(new_boxer);
                }
            }
            upperSearchingDone = true;
            return upperRank;
        }
        public List<Boxer> GetLowerRank(int n){
            for(int i = 0; i < lowerRank.Count; i++){
                if(lowerSearchingDone || upperRank.Count + lowerRank.Count == n - 1) return lowerRank;
                foreach(Boxer new_boxer in lowerRank[i].GetLowerRank(n)){
                    if(!lowerRank.Contains(new_boxer)) lowerRank.Add(new_boxer);
                }
            }
            lowerSearchingDone = true;
            return lowerRank;
        }
    }
}