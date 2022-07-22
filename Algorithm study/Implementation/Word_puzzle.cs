using System;
using System.Linq;
using System.Collections.Generic;

public class Solution {
    List<int> cases = new List<int>();
    public int solution(string[] strs,string t){
        int answer = 0;
        var Strs = strs.Select(s => new Str(s, t)).ToArray();
        List<bool[]> positions_list = new List<bool[]>();
        
        for(int i = 0; i < Strs.Length; i++){
            var temp_q = Strs[i].GetPositionsBoolArrayQ();
            while(temp_q.Count > 0){
                positions_list.Add(temp_q.Dequeue());
            }
        }
        positions_list = positions_list.OrderBy(arr => Array.IndexOf(arr, true)).ToList();
        Search(positions_list, 0, 0, 1);
        
        if(cases.Count == 0) return -1;
        return cases.Min(); 
     }
    public void Search(List<bool[]> positions_list, int start, int idx, int current){
        bool trigger = false;
        for(int i = start; i < positions_list.Count; i++){
            if(positions_list[i][idx] && (idx == 0 || !positions_list[i][idx - 1])){
                trigger = true;
                for(int j = idx; j < positions_list[i].Length; j++){
                    if(!positions_list[i][j]){
                        if(i == positions_list.Count - 1 || j == positions_list[i].Length - 1) break;
                        Search(positions_list, i + 1, j, current + 1);
                        break;
                    }
                    if(j == positions_list[i].Length - 1){
                        cases.Add(current);
                        return;
                    }
                }
            }
            
            if(trigger && !positions_list[i][idx]) return;
        }
    }
    
    public class Str{
        public string word;
        public int length;
        public int[] positions;
        
        public Str(string word, string target){
            this.word = word;
            length = word.Length;
            positions = new int[target.Length];
            int position = 0;
            while(position >= 0){
                position = target.IndexOf(word, position);
                if(position == -1) break;
                positions[position] = length;
                position++;
            }
        }
        
        public Queue<bool[]> GetPositionsBoolArrayQ(){
            Queue<bool[]> result = new Queue<bool[]>();
            for(int i = 0; i < positions.Length; i++){
                if(positions[i] > 0){
                    bool[] temp = new bool[positions.Length];
                    for(int j = i; j < i + length; j++){
                        temp[j] = true;
                    }
                    result.Enqueue(temp);
                }
            }
            return result;
        }
    }
 }