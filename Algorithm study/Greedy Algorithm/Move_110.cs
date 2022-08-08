using System;

public class Solution {
    public string[] solution(string[] s) {
        string[] answer = new string[s.Length];
        for(int i = 0; i < s.Length; i++){
            string temp = (string) s[i].Clone();
            while(temp.Contains("110")){
                temp = temp.Replace("110", "");
            }
            if(temp == null || temp.Length == 0){
                temp = "110";
                while(s[i].Length > temp.Length){
                    if(temp[temp.Length - 1].Equals('0')){
                        temp = temp.Insert(temp.Length, "110");
                    }else{
                        temp = temp.Insert(temp.Length - 1, "110");
                    }
                }
                answer[i] = temp;
                continue;
            }
            for(int j = 0; j < temp.Length - 1; j++){
                if(temp.Insert(j, "110").CompareTo(temp.Insert(j + 1, "110")) < 0){
                    if(j < temp.Length - 2 && temp.Insert(j, "110").CompareTo(temp.Insert(j + 2, "110")) > 0){
                        continue;
                    }
                    while(s[i].Length > temp.Length){
                        temp = temp.Insert(j, "110");
                    }
                    answer[i] = temp;
                    break;
                }
            }
            while(s[i].Length > temp.Length){
                if(temp[temp.Length - 1].Equals('0')){
                    temp = temp.Insert(temp.Length, "110");
                }else{
                    temp = temp.Insert(temp.Length - 1, "110");
                }
            }
            answer[i] = temp;
        }
        return answer;
    }
}