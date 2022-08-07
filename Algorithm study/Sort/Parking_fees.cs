using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] solution(int[] fees, string[] records) {
        List<int> answer = new List<int> ();
        records = records.OrderBy(s => s.Split(" ")[1]).ToArray();
        int time = 0;
        int used_time = 0;
        string car_num = "";
        string code = "";
        for(int i = 0; i < records.Length; i++){
            if(car_num.Equals(records[i].Split(" ")[1])){
                code = records[i].Split(" ")[2];
                if(code.Equals("IN")){
                    time = Int32.Parse(records[i].Split(" ")[0].Split(":")[0]) * 60 + Int32.Parse(records[i].Split(" ")[0].Split(":")[1]);
                }else{
                    used_time += Int32.Parse(records[i].Split(" ")[0].Split(":")[0]) * 60 + Int32.Parse(records[i].Split(" ")[0].Split(":")[1]) - time;
                    time = 0;
                }
            }else{
                car_num = records[i].Split(" ")[1];
                code = records[i].Split(" ")[2];
                time = Int32.Parse(records[i].Split(" ")[0].Split(":")[0]) * 60 + Int32.Parse(records[i].Split(" ")[0].Split(":")[1]);
                used_time = 0;
            }
            
            if(i < records.Length - 1 && car_num.Equals(records[i + 1].Split(" ")[1])){
                continue;
            }
            if(code.Equals("IN")) used_time += 23 * 60 + 59 - time;
            int charge = fees[1];
            if(used_time > fees[0]){
                used_time -= fees[0];
                charge += fees[3] * (used_time % fees[2] != 0 ? used_time/fees[2] + 1 : used_time/fees[2]);
            }
            answer.Add(charge);
        }
        return answer.ToArray();
    }
}