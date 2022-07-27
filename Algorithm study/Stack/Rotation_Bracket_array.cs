using System;
using System.Collections.Generic;

public class Solution {
    public int solution(string s) {
        int answer = 0;
        string temp = new string(s);
        for(int i = 0; i < s.Length; i++){
            if(isSatisfied(temp)) answer++;
            temp = temp.Substring(1, temp.Length - 1) + temp[0];
        }
        return answer;
    }
    
    public bool isSatisfied(string s){
        Stack<char> stack = new Stack<char>();
        for(int i = 0; i < s.Length; i++){
            if(stack.Count == 0){
                if(s[i].Equals(')') || s[i].Equals(']') || s[i].Equals('}')) return false;
                stack.Push(s[i]);
                continue;
            }
            switch(s[i]){
                case ')':
                    if(stack.Peek().Equals('(')) stack.Pop();
                    else return false;
                    break;
                case ']':
                    if(stack.Peek().Equals('[')) stack.Pop();
                    else return false;
                    break;
                case '}':
                    if(stack.Peek().Equals('{')) stack.Pop();
                    else return false;
                    break;
                default:
                    stack.Push(s[i]);
                    break;
            }
        }
        if(stack.Count > 0) return false;
        return true;
    }
}